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
    class PKW
    {
        public double Geschwindigkeit { get; private set; }
        public double xpos { get; private set; }
        public double ypos { get; private set; }
        private static Random r = new Random();
        public Ellipse e = new Ellipse();
        
    

        private int sign=1;

        public PKW (System.Windows.Controls.Canvas zeichenflaeche)
        {

            ypos = Convert.ToDouble(zeichenflaeche.ActualHeight) / 2;
            xpos = Convert.ToDouble(zeichenflaeche.ActualWidth)* r.NextDouble();

            Geschwindigkeit = 100 ;
        }
   
        public void Zeichen (Canvas zeichenflaeche, bool isAlted)
        {
            if (isAlted)
            {
                e.Fill = Brushes.Blue;
            }
            else
            {
                e.Fill = Brushes.Gray;
            }
   
            e.Width = 20;
            e.Height = 20;
            Canvas.SetLeft(e, xpos);
            Canvas.SetTop(e, ypos);
           
            zeichenflaeche.Children.Add(e);
        }

        public void Bewegen(TimeSpan interval,Canvas zeichenflaeche)
        {
            xpos += sign*Geschwindigkeit * interval.TotalSeconds;
            if (xpos >= zeichenflaeche.ActualWidth)
            {
                xpos = -20; 
            }
            else if (xpos <= -20)
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
            e.Fill = Brushes.DeepPink;
        }
    }

}
