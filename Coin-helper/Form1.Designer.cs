
namespace Coin_helper
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
            listView1 = new System.Windows.Forms.ListView();
            comboBox1 = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            comboBox2 = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            comboBox3 = new System.Windows.Forms.ComboBox();
            comboBox4 = new System.Windows.Forms.ComboBox();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new System.Drawing.Point(12, 87);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(766, 323);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(12, 58);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(121, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(674, 57);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(114, 23);
            button1.TabIndex = 2;
            button1.Text = "랭킹 보기(갱신)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(139, 58);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(121, 23);
            comboBox2.TabIndex = 4;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 15);
            label1.TabIndex = 5;
            label1.Text = "정렬 기준";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(139, 40);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 15);
            label2.TabIndex = 6;
            label2.Text = "기준 시간 단위";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(267, 58);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(121, 23);
            comboBox3.TabIndex = 7;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new System.Drawing.Point(394, 58);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(121, 23);
            comboBox4.TabIndex = 8;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(642, 416);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(136, 23);
            button2.TabIndex = 9;
            button2.Text = "프리미엄 비율 보기";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(12, 2);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(77, 23);
            button3.TabIndex = 10;
            button3.Text = "로그아웃";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(14, 416);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(119, 23);
            button4.TabIndex = 11;
            button4.Text = "관리자 페이지";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "증가량 순위";
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

