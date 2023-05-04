using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coin_helper
{
    public partial class AdminForm : Form
    {
        private int level;
        public AdminForm(int level)
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("No", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("id", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("이름", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("login", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("유저 등급", 120, HorizontalAlignment.Left);
            this.level = level;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ec2-35-72-70-146.ap-northeast-1.compute.amazonaws.com:8080/user/findAll");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                String jsonData = result.ToString();
                JArray jArray = JArray.Parse(jsonData);
                listView1.BeginUpdate();

                listView1.Items.Clear();

                for (int i = 0; i < jArray.Count(); i++)
                {
                    JToken jtoken = jArray[i];

                    ListViewItem lvi = new ListViewItem((i + 1).ToString());
                    lvi.SubItems.Add(jtoken["id"].ToString());
                    lvi.SubItems.Add(jtoken["name"].ToString());
                    if (jtoken["isOn"].ToString().Equals("1")) lvi.SubItems.Add("On");
                    else lvi.SubItems.Add("Off");
                    lvi.SubItems.Add(jtoken["level"].ToString());

                    listView1.Items.Add(lvi);
                }



                listView1.EndUpdate();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            JoinForm joinForm = new JoinForm();
            joinForm.Show();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {   
            ListViewItem lvItem = listView1.SelectedItems[0];
            if (!Form1.id.Equals(lvItem.SubItems[1].Text) && int.Parse(lvItem.SubItems[4].Text) >= level)
            {
                MessageBox.Show("Not Eligible");
                return;
            }
            ModifyForm form = new ModifyForm(lvItem.SubItems[1].Text, lvItem.SubItems[2].Text);
            form.Show();
        }
    }
}
