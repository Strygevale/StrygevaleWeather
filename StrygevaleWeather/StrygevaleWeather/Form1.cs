using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace StrygevaleWeather
 
{partial class Form1 : Form
    {

        private string weatherApi;
        private object cityRequest;
        private object units;








        public Form1()
        {
            InitializeComponent();
        }

        Button[] btns;
        TextBox[] tbs;
        private  void Form1_Load(object sender, EventArgs e)
        {
            btns = new Button[] { button1 };
            tbs = new TextBox[] { textBox1};
            this.button1.Click += new System.EventHandler(this.Button1_Click);


        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private async void Button1_Click(object sender, EventArgs e)
        {


            tbs[Array.IndexOf(btns, (sender as Button))].Text = "Омск";

        }

        private string GetRequest(object p)
        {
            throw new NotImplementedException();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Button2_Click(object sender, EventArgs e)
        {


            WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Omsk&appid=d9ef62e1a9cdca288189217e245bf78d");

            request.Method = "POST";

            request.ContentType = "application/x-www-urlencoded";

            WebResponse response = await request.GetResponseAsync();

            string answer = string.Empty;

            using (Stream s = response.GetResponseStream())
            {

                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            response.Close();

            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

           
            switch (comboBox1.SelectedIndex)
            {

                case 0: label3.Text = "Температура в °C: " + oW.main.temp.ToString("0.##"); break;
                case 1:  label3.Text = "Температура в °F: " + oW.main.temp_max.ToString(); break;
            }

            panel1.BackgroundImage = oW.weather[0].Icon;

            label8.Text = "Скорость (м/c): " + oW.wind.speed.ToString();
            label9.Text = "Направление: " + oW.wind.deg.ToString();
            label5.Text = "Влажность (%): " + oW.main.humidity.ToString();
            label6.Text = "Давление (мм)" + ((int)oW.main.pressure).ToString();
        }



        private async void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            
        }
    }
}