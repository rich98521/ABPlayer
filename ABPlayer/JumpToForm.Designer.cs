namespace ABPlayer
{
    partial class JumpToForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nmHour = new System.Windows.Forms.NumericUpDown();
            this.nmMin = new System.Windows.Forms.NumericUpDown();
            this.nmSec = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSec)).BeginInit();
            this.SuspendLayout();
            // 
            // nmHour
            // 
            this.nmHour.Location = new System.Drawing.Point(0, 1);
            this.nmHour.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmHour.Name = "nmHour";
            this.nmHour.Size = new System.Drawing.Size(55, 20);
            this.nmHour.TabIndex = 0;
            this.nmHour.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // nmMin
            // 
            this.nmMin.Location = new System.Drawing.Point(68, 1);
            this.nmMin.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmMin.Name = "nmMin";
            this.nmMin.Size = new System.Drawing.Size(37, 20);
            this.nmMin.TabIndex = 0;
            this.nmMin.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // nmSec
            // 
            this.nmSec.DecimalPlaces = 3;
            this.nmSec.Location = new System.Drawing.Point(118, 1);
            this.nmSec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmSec.Name = "nmSec";
            this.nmSec.Size = new System.Drawing.Size(58, 20);
            this.nmSec.TabIndex = 0;
            this.nmSec.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(176, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = ":";
            // 
            // JumpToForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 22);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nmSec);
            this.Controls.Add(this.nmMin);
            this.Controls.Add(this.nmHour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "JumpToForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jump To";
            ((System.ComponentModel.ISupportInitialize)(this.nmHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmHour;
        private System.Windows.Forms.NumericUpDown nmMin;
        private System.Windows.Forms.NumericUpDown nmSec;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}