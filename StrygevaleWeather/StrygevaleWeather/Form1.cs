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
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Omsk&APPID=d9ef62e1a9cdca288189217e245bf78d");

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

            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather> (answer);

            panel1.BackgroundImage = oW.weather[0].Icon;
            label2.Text = oW.weather[0].main;
            label3.Text = oW.weather[0].description;
            label4.Text = "Средняя температура (°C): " + oW.main.temp.ToString("0.##");
            label8.Text = "Скорость (м/c): " + oW.wind.speed.ToString();
            label9.Text = "Направление: " + oW.wind.deg.ToString();
            label5.Text = "Влажность (%): " + oW.main.humidity.ToString();
            label6.Text = "Давление (мм)" + ((int)oW.main.pressure).ToString();

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}