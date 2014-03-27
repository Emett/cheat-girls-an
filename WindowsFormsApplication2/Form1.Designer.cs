namespace WindowsFormsApplication2
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.allBox = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new WindowsFormsApplication2.ExtendedWebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerBox = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.blackBox1 = new System.Windows.Forms.TextBox();
            this.blackBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 121);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 149);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 177);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "0";
            // 
            // allBox
            // 
            this.allBox.Location = new System.Drawing.Point(12, 320);
            this.allBox.Name = "allBox";
            this.allBox.Size = new System.Drawing.Size(100, 22);
            this.allBox.TabIndex = 6;
            this.allBox.Text = "0";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Right;
            this.webBrowser1.Location = new System.Drawing.Point(155, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(904, 600);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.UserAgent = null;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerBox
            // 
            this.timerBox.Location = new System.Drawing.Point(93, 38);
            this.timerBox.Name = "timerBox";
            this.timerBox.Size = new System.Drawing.Size(47, 22);
            this.timerBox.TabIndex = 7;
            this.timerBox.Text = "15:00";
            this.timerBox.TextChanged += new System.EventHandler(this.timerBox_TextChanged);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // blackBox1
            // 
            this.blackBox1.Location = new System.Drawing.Point(12, 227);
            this.blackBox1.Name = "blackBox1";
            this.blackBox1.Size = new System.Drawing.Size(100, 22);
            this.blackBox1.TabIndex = 8;
            this.blackBox1.Text = "0";
            // 
            // blackBox2
            // 
            this.blackBox2.Location = new System.Drawing.Point(12, 255);
            this.blackBox2.Name = "blackBox2";
            this.blackBox2.Size = new System.Drawing.Size(100, 22);
            this.blackBox2.TabIndex = 9;
            this.blackBox2.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 600);
            this.Controls.Add(this.blackBox2);
            this.Controls.Add(this.blackBox1);
            this.Controls.Add(this.timerBox);
            this.Controls.Add(this.allBox);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendedWebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox allBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox timerBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox blackBox1;
        private System.Windows.Forms.TextBox blackBox2;
    }
}

