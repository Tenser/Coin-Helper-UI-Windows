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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Coin_helper
{
    public partial class Form1 : Form
    {
        private String sortRule;
        private String unit;
        private String currency;
        private String exchange;
        public static String id;
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("순위", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("이름", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("거래단위", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("거래소", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("가격", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("거래량", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("거래량 증가율(%)", 150, HorizontalAlignment.Left);
        }

        public void LoadComboBox()
        {
            String[] sortRules = { "volume", "price" };
            comboBox1.Items.AddRange(sortRules);
            comboBox1.SelectedIndex = 0;
            this.sortRule = (String) comboBox1.SelectedItem;

            String[] units = { "5", "60" };
            comboBox2.Items.AddRange(units);
            comboBox2.SelectedIndex = 0;
            this.unit = (String) comboBox2.SelectedItem;

            String[] currencys = { "KRW", "USDT" };
            comboBox3.Items.AddRange(currencys);
            comboBox3.SelectedIndex = 0;
            this.currency = (String)comboBox3.SelectedItem; 

            String[] exchanges = { "upbit", "binance" };
            comboBox4.Items.AddRange(exchanges);
            comboBox4.SelectedIndex = 0;
            this.exchange = (String)comboBox4.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (WebClient wc = new WebClient())
            { 
                var json = wc.DownloadString("http://ec2-52-68-10-201.ap-northeast-1.compute.amazonaws.com:8080/coin/" + this.sortRule + "/ranking/" + unit + "/" + currency + "/" + exchange);
                String jsonData = json.ToString();
                JArray jArray = JArray.Parse(jsonData);

                listView1.BeginUpdate();

                listView1.Columns.RemoveAt(6);

                if (sortRule.Equals("volume"))
                    listView1.Columns.Add("거래량 증가율(%)", 150, HorizontalAlignment.Left);
                else
                    listView1.Columns.Add("가격 증가율(%)", 150, HorizontalAlignment.Left);

                listView1.Items.Clear();

                for (int i = 0; i < jArray.Count(); i++)
                {
                    JToken jtoken = jArray[i];
                    if (Double.Parse(jtoken["beforeVolume"].ToString()).Equals(0.0)) continue;
                    
                    ListViewItem lvi = new ListViewItem((i+1).ToString());
                    lvi.SubItems.Add(jtoken["name"].ToString());
                    lvi.SubItems.Add(jtoken["currency"].ToString());
                    lvi.SubItems.Add(jtoken["exchange"].ToString());
                    double volume = Double.Parse(jtoken["nowVolume"].ToString());
                    double price = Double.Parse(jtoken["nowPrice"].ToString());
                    lvi.SubItems.Add(price.ToString());
                    lvi.SubItems.Add(volume.ToString());
                    
                    if (this.sortRule.Equals("volume")) 
                        lvi.SubItems.Add(((volume / Double.Parse(jtoken["beforeVolume"].ToString()) - 1) * 100).ToString() + "%");
                    else
                        lvi.SubItems.Add(((price / Double.Parse(jtoken["beforePrice"].ToString()) - 1) * 100).ToString() + "%");
                    
                    listView1.Items.Add(lvi);
                }

                

                listView1.EndUpdate();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sortRule = (String)comboBox1.SelectedItem;
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.unit = (String)comboBox2.SelectedItem;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadListView();
            LoadComboBox();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currency = (String)comboBox3.SelectedItem;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.exchange = (String)comboBox4.SelectedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ec2-52-68-10-201.ap-northeast-1.compute.amazonaws.com:8080/user/logout");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"id\":\"" + Form1.id + "\", \"password\": \"\"}";
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
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(jObject["message"].ToString() + "sex");
                }
            }
        }
    }
}
