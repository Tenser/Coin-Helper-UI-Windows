using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Coin_helper
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ec2-52-68-10-201.ap-northeast-1.compute.amazonaws.com:8080/user/login");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"id\":\"" + textBox1.Text + "\", \"password\":" + textBox2.Text + "}";

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
                    Form1.id = textBox1.Text;
                    loginSuccess();
                }
                else
                {
                    MessageBox.Show(jObject["message"].ToString());
                }
            }
            
        }

        private void loginSuccess()
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Visible = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
