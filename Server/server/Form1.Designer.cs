namespace server
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
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.richTextBox_clients = new System.Windows.Forms.RichTextBox();
            this.richTextBox_if = new System.Windows.Forms.RichTextBox();
            this.richTextBox_sps = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.connected_count = new System.Windows.Forms.Label();
            this.if_count = new System.Windows.Forms.Label();
            this.sps_count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(15, 35);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(1);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(189, 20);
            this.textBox_port.TabIndex = 0;
            this.textBox_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_port.TextChanged += new System.EventHandler(this.textBox_port_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // button_listen
            // 
            this.button_listen.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_listen.Location = new System.Drawing.Point(15, 63);
            this.button_listen.Margin = new System.Windows.Forms.Padding(1);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(188, 22);
            this.button_listen.TabIndex = 2;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(15, 136);
            this.logs.Margin = new System.Windows.Forms.Padding(1);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(189, 224);
            this.logs.TabIndex = 3;
            this.logs.Text = "";
            // 
            // richTextBox_clients
            // 
            this.richTextBox_clients.Location = new System.Drawing.Point(239, 135);
            this.richTextBox_clients.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_clients.Name = "richTextBox_clients";
            this.richTextBox_clients.Size = new System.Drawing.Size(177, 225);
            this.richTextBox_clients.TabIndex = 7;
            this.richTextBox_clients.Text = "";
            // 
            // richTextBox_if
            // 
            this.richTextBox_if.Location = new System.Drawing.Point(433, 135);
            this.richTextBox_if.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_if.Name = "richTextBox_if";
            this.richTextBox_if.Size = new System.Drawing.Size(176, 224);
            this.richTextBox_if.TabIndex = 8;
            this.richTextBox_if.Text = "";
            // 
            // richTextBox_sps
            // 
            this.richTextBox_sps.Location = new System.Drawing.Point(626, 135);
            this.richTextBox_sps.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_sps.Name = "richTextBox_sps";
            this.richTextBox_sps.Size = new System.Drawing.Size(171, 224);
            this.richTextBox_sps.TabIndex = 9;
            this.richTextBox_sps.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(259, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Connected Clients";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(452, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "IF Channel Clients";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(635, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "SPS Channel Clients";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(33, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Connection Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label7.Location = new System.Drawing.Point(308, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(399, 44);
            this.label7.TabIndex = 14;
            this.label7.Text = "DiSUcord Server GUI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(235, 362);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "User Count: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(429, 362);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "User Count: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(622, 362);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "User Count: ";
            // 
            // connected_count
            // 
            this.connected_count.AutoSize = true;
            this.connected_count.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.connected_count.Location = new System.Drawing.Point(327, 361);
            this.connected_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.connected_count.Name = "connected_count";
            this.connected_count.Size = new System.Drawing.Size(19, 20);
            this.connected_count.TabIndex = 18;
            this.connected_count.Text = "0";
            // 
            // if_count
            // 
            this.if_count.AutoSize = true;
            this.if_count.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.if_count.Location = new System.Drawing.Point(526, 361);
            this.if_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.if_count.Name = "if_count";
            this.if_count.Size = new System.Drawing.Size(19, 20);
            this.if_count.TabIndex = 19;
            this.if_count.Text = "0";
            // 
            // sps_count
            // 
            this.sps_count.AutoSize = true;
            this.sps_count.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sps_count.Location = new System.Drawing.Point(718, 362);
            this.sps_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sps_count.Name = "sps_count";
            this.sps_count.Size = new System.Drawing.Size(19, 20);
            this.sps_count.TabIndex = 20;
            this.sps_count.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(818, 415);
            this.Controls.Add(this.sps_count);
            this.Controls.Add(this.if_count);
            this.Controls.Add(this.connected_count);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox_sps);
            this.Controls.Add(this.richTextBox_if);
            this.Controls.Add(this.richTextBox_clients);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_port);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.RichTextBox richTextBox_clients;
        private System.Windows.Forms.RichTextBox richTextBox_if;
        private System.Windows.Forms.RichTextBox richTextBox_sps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label connected_count;
        private System.Windows.Forms.Label if_count;
        private System.Windows.Forms.Label sps_count;
    }
}

