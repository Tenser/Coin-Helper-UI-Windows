namespace Coin_helper
{
    partial class AdminForm
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
            listView1 = new System.Windows.Forms.ListView();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new System.Drawing.Point(95, 91);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(619, 323);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.DoubleClick += listView1_DoubleClick;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(95, 62);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(119, 23);
            button1.TabIndex = 1;
            button1.Text = "회원 정보보기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(639, 62);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "회원 추가";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "AdminForm";
            Text = "AdminForm";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}