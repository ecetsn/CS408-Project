namespace client
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.connection_log = new System.Windows.Forms.RichTextBox();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.if100_log = new System.Windows.Forms.RichTextBox();
            this.sps101_log = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button_sps_unsub = new System.Windows.Forms.Button();
            this.button_if_unsub = new System.Windows.Forms.Button();
            this.button_sps_sub = new System.Windows.Forms.Button();
            this.button_if_sub = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton_sps = new System.Windows.Forms.RadioButton();
            this.radioButton_if = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.button_clear_connection = new System.Windows.Forms.Button();
            this.button_clear_if = new System.Windows.Forms.Button();
            this.button_clear_sps = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(67, 51);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(1);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(122, 20);
            this.textBox_ip.TabIndex = 2;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(67, 79);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(1);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(122, 20);
            this.textBox_port.TabIndex = 3;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(67, 144);
            this.button_connect.Margin = new System.Windows.Forms.Padding(1);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(121, 23);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // connection_log
            // 
            this.connection_log.Enabled = false;
            this.connection_log.Location = new System.Drawing.Point(240, 182);
            this.connection_log.Margin = new System.Windows.Forms.Padding(1);
            this.connection_log.Name = "connection_log";
            this.connection_log.Size = new System.Drawing.Size(192, 315);
            this.connection_log.TabIndex = 5;
            this.connection_log.Text = "";
            // 
            // textBox_message
            // 
            this.textBox_message.Enabled = false;
            this.textBox_message.Location = new System.Drawing.Point(319, 539);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(1);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(400, 20);
            this.textBox_message.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(215, 536);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message:";
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(747, 534);
            this.button_send.Margin = new System.Windows.Forms.Padding(1);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(121, 26);
            this.button_send.TabIndex = 8;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(67, 110);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(122, 20);
            this.textBox_name.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Username:";
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(67, 178);
            this.button_disconnect.Margin = new System.Windows.Forms.Padding(1);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(121, 23);
            this.button_disconnect.TabIndex = 11;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click_1);
            // 
            // if100_log
            // 
            this.if100_log.Enabled = false;
            this.if100_log.Location = new System.Drawing.Point(463, 181);
            this.if100_log.Margin = new System.Windows.Forms.Padding(1);
            this.if100_log.Name = "if100_log";
            this.if100_log.Size = new System.Drawing.Size(192, 315);
            this.if100_log.TabIndex = 12;
            this.if100_log.Text = "";
            // 
            // sps101_log
            // 
            this.sps101_log.Enabled = false;
            this.sps101_log.Location = new System.Drawing.Point(673, 181);
            this.sps101_log.Margin = new System.Windows.Forms.Padding(1);
            this.sps101_log.Name = "sps101_log";
            this.sps101_log.Size = new System.Drawing.Size(192, 315);
            this.sps101_log.TabIndex = 13;
            this.sps101_log.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(240, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Connection Log";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(463, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "IF100 Log";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(673, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "SPS101 Log";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.button_sps_unsub);
            this.groupBox1.Controls.Add(this.button_if_unsub);
            this.groupBox1.Controls.Add(this.button_sps_sub);
            this.groupBox1.Controls.Add(this.button_if_sub);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.radioButton_sps);
            this.groupBox1.Controls.Add(this.radioButton_if);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(9, 247);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(227, 250);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(176, 159);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(18, 157);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Sending message to:";
            // 
            // button_sps_unsub
            // 
            this.button_sps_unsub.Enabled = false;
            this.button_sps_unsub.Location = new System.Drawing.Point(129, 113);
            this.button_sps_unsub.Margin = new System.Windows.Forms.Padding(1);
            this.button_sps_unsub.Name = "button_sps_unsub";
            this.button_sps_unsub.Size = new System.Drawing.Size(80, 23);
            this.button_sps_unsub.TabIndex = 23;
            this.button_sps_unsub.Text = "Unsubscribe";
            this.button_sps_unsub.UseVisualStyleBackColor = true;
            this.button_sps_unsub.Click += new System.EventHandler(this.button_sps_unsub_Click);
            // 
            // button_if_unsub
            // 
            this.button_if_unsub.Enabled = false;
            this.button_if_unsub.Location = new System.Drawing.Point(21, 113);
            this.button_if_unsub.Margin = new System.Windows.Forms.Padding(1);
            this.button_if_unsub.Name = "button_if_unsub";
            this.button_if_unsub.Size = new System.Drawing.Size(80, 23);
            this.button_if_unsub.TabIndex = 22;
            this.button_if_unsub.Text = "Unsubscribe";
            this.button_if_unsub.UseVisualStyleBackColor = true;
            this.button_if_unsub.Click += new System.EventHandler(this.button_if_unsub_Click);
            // 
            // button_sps_sub
            // 
            this.button_sps_sub.Location = new System.Drawing.Point(129, 70);
            this.button_sps_sub.Margin = new System.Windows.Forms.Padding(1);
            this.button_sps_sub.Name = "button_sps_sub";
            this.button_sps_sub.Size = new System.Drawing.Size(80, 23);
            this.button_sps_sub.TabIndex = 21;
            this.button_sps_sub.Text = "Subscribe";
            this.button_sps_sub.UseVisualStyleBackColor = true;
            this.button_sps_sub.Click += new System.EventHandler(this.button_sps_sub_Click);
            // 
            // button_if_sub
            // 
            this.button_if_sub.Location = new System.Drawing.Point(21, 70);
            this.button_if_sub.Margin = new System.Windows.Forms.Padding(1);
            this.button_if_sub.Name = "button_if_sub";
            this.button_if_sub.Size = new System.Drawing.Size(80, 23);
            this.button_if_sub.TabIndex = 18;
            this.button_if_sub.Text = "Subscribe";
            this.button_if_sub.UseVisualStyleBackColor = true;
            this.button_if_sub.Click += new System.EventHandler(this.button_if_sub_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(133, 36);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "SPS101";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(34, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "IF100";
            // 
            // radioButton_sps
            // 
            this.radioButton_sps.AutoSize = true;
            this.radioButton_sps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton_sps.Location = new System.Drawing.Point(115, 187);
            this.radioButton_sps.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButton_sps.Name = "radioButton_sps";
            this.radioButton_sps.Size = new System.Drawing.Size(77, 21);
            this.radioButton_sps.TabIndex = 19;
            this.radioButton_sps.TabStop = true;
            this.radioButton_sps.Text = "SPS101";
            this.radioButton_sps.UseVisualStyleBackColor = true;
            this.radioButton_sps.CheckedChanged += new System.EventHandler(this.radioButton_sps_CheckedChanged);
            // 
            // radioButton_if
            // 
            this.radioButton_if.AutoSize = true;
            this.radioButton_if.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton_if.Location = new System.Drawing.Point(37, 187);
            this.radioButton_if.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButton_if.Name = "radioButton_if";
            this.radioButton_if.Size = new System.Drawing.Size(61, 21);
            this.radioButton_if.TabIndex = 18;
            this.radioButton_if.TabStop = true;
            this.radioButton_if.Text = "IF100";
            this.radioButton_if.UseVisualStyleBackColor = true;
            this.radioButton_if.CheckedChanged += new System.EventHandler(this.radioButton_if_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label12.Location = new System.Drawing.Point(386, 57);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(365, 44);
            this.label12.TabIndex = 18;
            this.label12.Text = "DiSUcord User GUI";
            // 
            // button_clear_connection
            // 
            this.button_clear_connection.Location = new System.Drawing.Point(240, 499);
            this.button_clear_connection.Margin = new System.Windows.Forms.Padding(1);
            this.button_clear_connection.Name = "button_clear_connection";
            this.button_clear_connection.Size = new System.Drawing.Size(192, 23);
            this.button_clear_connection.TabIndex = 19;
            this.button_clear_connection.Text = "Clear";
            this.button_clear_connection.UseVisualStyleBackColor = true;
            this.button_clear_connection.Click += new System.EventHandler(this.button_clear_connection_Click);
            // 
            // button_clear_if
            // 
            this.button_clear_if.Location = new System.Drawing.Point(463, 499);
            this.button_clear_if.Margin = new System.Windows.Forms.Padding(1);
            this.button_clear_if.Name = "button_clear_if";
            this.button_clear_if.Size = new System.Drawing.Size(192, 23);
            this.button_clear_if.TabIndex = 20;
            this.button_clear_if.Text = "Clear";
            this.button_clear_if.UseVisualStyleBackColor = true;
            this.button_clear_if.Click += new System.EventHandler(this.button_clear_if_Click);
            // 
            // button_clear_sps
            // 
            this.button_clear_sps.Location = new System.Drawing.Point(673, 498);
            this.button_clear_sps.Margin = new System.Windows.Forms.Padding(1);
            this.button_clear_sps.Name = "button_clear_sps";
            this.button_clear_sps.Size = new System.Drawing.Size(192, 23);
            this.button_clear_sps.TabIndex = 21;
            this.button_clear_sps.Text = "Clear";
            this.button_clear_sps.UseVisualStyleBackColor = true;
            this.button_clear_sps.Click += new System.EventHandler(this.button_clear_sps_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(897, 591);
            this.Controls.Add(this.button_clear_sps);
            this.Controls.Add(this.button_clear_if);
            this.Controls.Add(this.button_clear_connection);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sps101_log);
            this.Controls.Add(this.if100_log);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.connection_log);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox connection_log;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.RichTextBox if100_log;
        private System.Windows.Forms.RichTextBox sps101_log;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_sps_unsub;
        private System.Windows.Forms.Button button_if_unsub;
        private System.Windows.Forms.Button button_sps_sub;
        private System.Windows.Forms.Button button_if_sub;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton_sps;
        private System.Windows.Forms.RadioButton radioButton_if;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button_clear_connection;
        private System.Windows.Forms.Button button_clear_if;
        private System.Windows.Forms.Button button_clear_sps;
    }
}

