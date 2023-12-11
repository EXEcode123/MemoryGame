namespace MemoryGameProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblStatus = new Label();
            lblTimeLeft = new Label();
            btnRestart = new Button();
            GameTimer = new System.Windows.Forms.Timer(components);
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = SystemColors.ActiveCaption;
            lblStatus.Location = new Point(262, 141);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(111, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Match or MisMatch";
            // 
            // lblTimeLeft
            // 
            lblTimeLeft.AutoSize = true;
            lblTimeLeft.BackColor = SystemColors.ActiveCaption;
            lblTimeLeft.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimeLeft.Location = new Point(262, 213);
            lblTimeLeft.Name = "lblTimeLeft";
            lblTimeLeft.Size = new Size(104, 21);
            lblTimeLeft.TabIndex = 1;
            lblTimeLeft.Text = "Time left: 30";
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnRestart.Location = new Point(262, 25);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(140, 72);
            btnRestart.TabIndex = 2;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += RestartGameEvent;
            // 
            // GameTimer
            // 
            GameTimer.Interval = 1000;
            GameTimer.Tick += TimerEvent;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkViolet;
            textBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(262, 270);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 35);
            textBox1.TabIndex = 3;
            textBox1.Text = "MemoryGame";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 341);
            Controls.Add(textBox1);
            Controls.Add(btnRestart);
            Controls.Add(lblTimeLeft);
            Controls.Add(lblStatus);
            Name = "Form1";
            Text = "Enes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Label lblTimeLeft;
        private Button btnRestart;
        private System.Windows.Forms.Timer GameTimer;
        private TextBox textBox1;
    }
}