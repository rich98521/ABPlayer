using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using Un4seen.Bass;
using System.Runtime.InteropServices;
using Un4seen.Bass.AddOn.Fx;
using Un4seen.Bass.AddOn.Mix;

namespace ABPlayer
{
    public delegate void AudioPlayingEventHandler(TimeSpan newTime);
    public delegate void AudioCompletedEventHandler();
    static class AudioPlayer
    {
        public static event AudioPlayingEventHandler AudioPlaying;
        public static event AudioCompletedEventHandler AudioCompleted;
        static bool playing;
        static bool fileLoaded;
        static float volume = 1;
        static float speed = 1;
        static bool mono;
        static CancellationTokenSource cancelToken = new CancellationTokenSource();
        static ManualResetEvent mre = new ManualResetEvent(false);
        static int baseStreamHandle, mixStreamHandle, streamHandle;
        static SYNCPROC syncProc;
        static Task updateTask;
        //static DSPPROC dspProc;

        static AudioPlayer()
        {
            updateTask = new Task(UpdateTime, cancelToken.Token, TaskCreationOptions.LongRunning);
            updateTask.Start();
        }

        public static float Volume
        {
            get { return volume; }
            set { volume = value; Bass.BASS_ChannelSetAttribute(streamHandle, BASSAttribute.BASS_ATTRIB_VOL, value); }
        }

        public static float Speed
        {
            get { return speed; }
            set { speed = value; Bass.BASS_ChannelSetAttribute(streamHandle, BASSAttribute.BASS_ATTRIB_TEMPO, (value - 1) * 100); }
        }

        public static bool Mono
        {
            get { return mono; }
            set
            {
                mono = value;
                float[,] matrix = new float[,] { { 1, 0 }, { 0, 1 } };
                if (value)
                    matrix = new float[,] { { 1, 1 }, { 1, 1 } };
                BassMix.BASS_Mixer_ChannelSetMatrix(baseStreamHandle, matrix);
            }
        }

        public static bool Playing
        {
            get { return playing; }
            private set { if (value) mre.Set(); playing = value; }
        }

        public static bool FileLoaded
        {
            get { return fileLoaded; }
            private set { if (!value) Playing = false; fileLoaded = value; }
        }

        private static void RaiseEventOnUIThread(Delegate theEvent, params object[] args)
        {
            foreach (Delegate d in theEvent.GetInvocationList())
            {
                ISynchronizeInvoke syncer = d.Target as ISynchronizeInvoke;
                try
                {
                    if (syncer == null)
                        d.DynamicInvoke(args);
                    else
                        syncer.BeginInvoke(d, args);
                }
                catch { }
            }
        }

        public static void Play(string file, bool loadOnly)
        {
            Stop();
            baseStreamHandle = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_STREAM_DECODE);
            BASS_CHANNELINFO info = Bass.BASS_ChannelGetInfo(baseStreamHandle);
            mixStreamHandle = BassMix.BASS_Mixer_StreamCreate(info.freq, info.chans, BASSFlag.BASS_STREAM_DECODE);
            BassMix.BASS_Mixer_StreamAddChannel(mixStreamHandle, baseStreamHandle, BASSFlag.BASS_MIXER_MATRIX);
            streamHandle = BassFx.BASS_FX_TempoCreate(mixStreamHandle, BASSFlag.BASS_FX_FREESOURCE);
            Mono = mono;
            Speed = speed;
            if (!loadOnly)
                Bass.BASS_ChannelPlay(streamHandle, false);
            BASSError er = Bass.BASS_ErrorGetCode();
            syncProc = new SYNCPROC(AudioEnded);
            Bass.BASS_ChannelSetSync(streamHandle, BASSSync.BASS_SYNC_END, 0, syncProc, IntPtr.Zero);
            Playing = !loadOnly;
            FileLoaded = true;
        }

        public static void Continue()
        {
            Bass.BASS_ChannelPlay(streamHandle, false);
            Playing = true;
        }

        public static void Pause()
        {
            Bass.BASS_ChannelPause(streamHandle);
            Playing = false;
        }

        public static void Stop()
        {
            Bass.BASS_ChannelStop(streamHandle);
            Bass.BASS_StreamFree(streamHandle);
            Playing = false;
            FileLoaded = false;
        }

        public static void PlayPause(string file)
        {
            if (FileLoaded)
                if (Playing)
                    Pause();
                else
                    Continue();
            else
                Play(file, false);
        }

        private static void UpdateTime()
        {
            while (true)
            {
                cancelToken.Token.WaitHandle.WaitOne(100);
                if (cancelToken.IsCancellationRequested)
                    break;
                if (!Playing)
                {
                    mre.WaitOne();
                    mre.Reset();
                }

                TimeSpan playedSoFar = new TimeSpan(0, 0, 0, 0,
                    (int)(Bass.BASS_ChannelBytes2Seconds(mixStreamHandle, Bass.BASS_ChannelGetPosition(baseStreamHandle, BASSMode.BASS_POS_BYTES)) * 1000));

                RaiseEventOnUIThread(AudioPlaying, playedSoFar);
            }
        }

        public static void JumpTo(TimeSpan t)
        {
            BassMix.BASS_Mixer_ChannelSetPosition(baseStreamHandle, (long)(Bass.BASS_ChannelSeconds2Bytes(baseStreamHandle, 1) * t.TotalSeconds), BASSMode.BASS_POS_BYTES);
        }

        private static void AudioEnded(int handle, int channel, int data, IntPtr user)
        {
            FileLoaded = false;
            RaiseEventOnUIThread(AudioCompleted);
        }

        //private static void DSP(int handle, int channel, IntPtr buffer, int length, IntPtr user)
        //{
        //    unsafe
        //    {
        //        float* ptr = (float*)buffer.ToPointer();
        //        for (int i = 0; i < length; i+=channelCount)
        //        {
        //            for(int i2=0;i2<channelCount;i2++)
        //            {
        //                ptr[i + i2] *= Volume;
        //            }
        //        }
        //    }
        //}
    }
}







