using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Coin_helper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void LoadListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("이름", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("upbit 가격(KRW)", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("binance 가격(USDT)", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("프리미엄 비율", 150, HorizontalAlignment.Left);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://ec2-52-68-10-201.ap-northeast-1.compute.amazonaws.com:8080/coin/premium");
                String jsonData = json.ToString();
                JArray jArray = JArray.Parse(jsonData);

                listView1.BeginUpdate();

                listView1.Items.Clear();

                for (int i = 0; i < jArray.Count(); i++)
                {
                    JToken jtoken = jArray[i];

                    ListViewItem lvi = new ListViewItem(jtoken["coinName"].ToString());
                    lvi.SubItems.Add(jtoken["priceKorea"].ToString());
                    lvi.SubItems.Add(jtoken["priceAmerica"].ToString());
                    lvi.SubItems.Add(((Double.Parse(jtoken["premium"].ToString()) - 1.0) * 100.0).ToString() + "%");

                    listView1.Items.Add(lvi);
                }



                listView1.EndUpdate();

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadListView();
        }
    }
}
