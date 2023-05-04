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

namespace Coin_helper
{
    public partial class ModifyForm : Form
    {
        private String id;
        public ModifyForm(String id, String name)
        {
            InitializeComponent();
            this.id = id;
            textBox1.Text = id;
            textBox3.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "") return;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ec2-35-72-70-146.ap-northeast-1.compute.amazonaws.com:8080/user/updateInform/" + id);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"password\":\"" + textBox2.Text + "\", \"name\":\"" + textBox3.Text + "\"}";
                //MessageBox.Show(json);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                String jsonData = result.ToString();
                JObject jObject = JObject.Parse(jsonData);
                if (jObject["message"].ToString().Equals("OK"))
                {
                    MessageBox.Show(jObject["message"].ToString());
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show(jObject["message"].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ec2-35-72-70-146.ap-northeast-1.compute.amazonaws.com:8080/user/delete/" + id);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                String jsonData = result.ToString();
                JObject jObject = JObject.Parse(jsonData);
                if (jObject["message"].ToString().Equals("OK"))
                {
                    MessageBox.Show(jObject["message"].ToString());
                    Close();
                }
                else
                {
                    MessageBox.Show(jObject["message"].ToString());
                }
            }
        }
    }
}
