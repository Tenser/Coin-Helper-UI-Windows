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
    public partial class JoinForm : Form
    {
        public JoinForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ec2-35-72-70-146.ap-northeast-1.compute.amazonaws.com:8080/user/save");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"id\":\"" + textBox1.Text + "\", \"password\":\"" + textBox2.Text + "\", \"name\":\"" + textBox3.Text +"\"}";
                //MessageBox.Show(json);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                int success = int.Parse(result.ToString());
           

                if (success > 0)
                {
                    MessageBox.Show("성공!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                    MessageBox.Show("실패");
            }
        }
    }
}
