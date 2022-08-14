namespace Tetris
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Net = new System.Windows.Forms.PictureBox();
            this.TestButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Nexttetromino = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Net)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nexttetromino)).BeginInit();
            this.SuspendLayout();
            // 
            // Net
            // 
            this.Net.Location = new System.Drawing.Point(85, 49);
            this.Net.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Net.Name = "Net";
            this.Net.Size = new System.Drawing.Size(328, 423);
            this.Net.TabIndex = 0;
            this.Net.TabStop = false;
            this.Net.Paint += new System.Windows.Forms.PaintEventHandler(this.Net_Paint);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(481, 28);
            this.TestButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(107, 55);
            this.TestButton.TabIndex = 1;
            this.TestButton.Text = "Reset";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(483, 99);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 66);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(485, 185);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 57);
            this.button2.TabIndex = 3;
            this.button2.Text = "AI";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(485, 259);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 54);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(5, 56);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 27);
            this.button4.TabIndex = 7;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(37, 56);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 28);
            this.button5.TabIndex = 8;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 0;
            // 
            // Nexttetromino
            // 
            this.Nexttetromino.Location = new System.Drawing.Point(456, 335);
            this.Nexttetromino.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Nexttetromino.Name = "Nexttetromino";
            this.Nexttetromino.Size = new System.Drawing.Size(152, 136);
            this.Nexttetromino.TabIndex = 9;
            this.Nexttetromino.TabStop = false;
            this.Nexttetromino.Paint += new System.Windows.Forms.PaintEventHandler(this.Next_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 508);
            this.Controls.Add(this.Nexttetromino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.Net);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Net)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nexttetromino)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Net;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Nexttetromino;
    }
}

