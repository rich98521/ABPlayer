using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using Un4seen.Bass;

namespace ABPlayer
{
    public delegate void AudioPlayingEventHandler(TimeSpan newTime);
    public delegate void AudioCompletedEventHandler();
    static class AudioPlayer
    {//fileended event
        public static event AudioPlayingEventHandler AudioPlaying;
        public static event AudioCompletedEventHandler AudioCompleted;
        public static string CurrentFile { get; private set; } = "";
        public static bool Playing { get; private set; }
        public static float Volume { get; set; }
        public static float Speed { get; set; }
        static CancellationTokenSource cancelToken = new CancellationTokenSource();
        static ManualResetEvent mre = new ManualResetEvent(false);
        static int streamHandle;

        public static void PlayPause(string file)
        {
            if (!Playing)
                PlayFile(file);
            else
            {
                //playpause
                Playing = !Playing;
            }
        }

        private static void RaiseEventOnUIThread(Delegate theEvent, params object[] args)
        {
            foreach (Delegate d in theEvent.GetInvocationList())
            {
                ISynchronizeInvoke syncer = d.Target as ISynchronizeInvoke;
                if (syncer == null)
                {
                    d.DynamicInvoke(args);
                }
                else
                {
                    syncer.BeginInvoke(d, args);
                }
            }
        }

        public static void Pause()
        {
            Playing = false;
        }

        public static void Continue()
        {
            Playing = true;
            mre.Set();
        }

        public static void PlayFile(string file)
        {
            //playfile
            Playing = true;
            CurrentFile = file;

            Task playTask = new Task(PlayTask, cancelToken.Token, TaskCreationOptions.LongRunning);
            playTask.Start();
        }

        public static void SetPlayed(TimeSpan t)
        {
            //Bass.BASS_ChannelSetPosition(streamHandle, t.TotalSeconds);
            Bass.BASS_ChannelSetPosition(streamHandle, (long)(Bass.BASS_ChannelSeconds2Bytes(streamHandle, 1) * t.TotalSeconds), BASSMode.BASS_POS_INEXACT | BASSMode.BASS_POS_BYTES);
        }

        private static void AudioEnded(int handle, int channel, int data, IntPtr user)
        {
            RaiseEventOnUIThread(AudioCompleted);
        }

        private static void PlayTask()
        {
            streamHandle = Bass.BASS_StreamCreateFile(CurrentFile, 0, 0, 0);
            Bass.BASS_ChannelPlay(streamHandle, false);
            Bass.BASS_ChannelSetSync(streamHandle, BASSSync.BASS_SYNC_END, 0, new SYNCPROC(AudioEnded), IntPtr.Zero);
            while (true)
            {
                cancelToken.Token.WaitHandle.WaitOne(100);
                if (!Playing)
                {
                    Bass.BASS_ChannelPause(streamHandle);
                    mre.WaitOne();
                    mre.Reset();
                    Bass.BASS_ChannelPlay(streamHandle, false);
                }

                TimeSpan playedSoFar = new TimeSpan(0, 0, 0, 0, 
                    (int)(Bass.BASS_ChannelBytes2Seconds(streamHandle, Bass.BASS_ChannelGetPosition(streamHandle, BASSMode.BASS_POS_BYTES)) * 1000));

                RaiseEventOnUIThread(AudioPlaying, playedSoFar);
            }
        }
    }
}







