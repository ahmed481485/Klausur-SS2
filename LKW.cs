using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Klausur_SS2
{
    class LKW
    {
        public double Geschwindigkeit { get; set; }
        public double xpos { get; set; }
        public double ypos { get; set; }
    
        private static Random r = new Random();
        private int sign = 1;

        public LKW(System.Windows.Controls.Canvas zeichenflaeche)
        {

            ypos = Convert.ToDouble(zeichenflaeche.ActualHeight) / 2 + 50;
            xpos = Convert.ToDouble(zeichenflaeche.ActualWidth) * r.NextDouble();
       

            Geschwindigkeit = 70;
        }
        public Rectangle t = new Rectangle();
        public void Zeichen(Canvas zeichenflaeche, bool isAlted)
        {
           
            t.Width = 30;
            t.Height = 20;
            Canvas.SetLeft(t, xpos);
            Canvas.SetTop(t, ypos);
            if (isAlted)
            {
                t.Fill = Brushes.Gray;

            }
            else
            {
                t.Fill = Brushes.Blue;

            }
         
            zeichenflaeche.Children.Add(t);
        }

        public void Bewegen(TimeSpan interval, Canvas zeichenflaeche)
        {
            xpos += sign* Geschwindigkeit * interval.TotalSeconds;
            if (xpos >= zeichenflaeche.ActualWidth)
            {
                xpos = -30;
            }
            else if (xpos <= -30)
            {
                xpos = zeichenflaeche.ActualWidth;
            }

        }
        public void links()
        {
            sign = -1;
        }
        public void Rechts()
        {
            sign = 1;
        }
        public void Farbe()
        {
            t.Fill = Brushes.DeepPink;
        }
    }
    
}
