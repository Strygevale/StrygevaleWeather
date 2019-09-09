using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StrygevaleWeather.OpenWeather
{
    class Weather
    {
        public int id;

        public string main;

        public string description;

        private string icon;

        public Bitmap Icon
        {
            get
            {
                return new Bitmap(Image.FromFile("icons/{icon}.png")
            }
        }
    }
}
