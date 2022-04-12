using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Klausur_SS2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        List< PKW> pkw= new List<PKW>();
        List<LKW> lkw = new List<LKW>();
        DispatcherTimer timer = new DispatcherTimer();
        public bool isAlted;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(17);            
            timer.Tick += anemiere;

            
        }

        private void anemiere(object sender, EventArgs e)
        {
            Zeichenflaeche.Children.Clear();
            foreach (PKW item in pkw)
            {
                item.Bewegen(timer.Interval,Zeichenflaeche);
                item.Zeichen(Zeichenflaeche,isAlted);
            }
            foreach(LKW item in lkw)
            {
                item.Bewegen(timer.Interval, Zeichenflaeche);
                item.Zeichen(Zeichenflaeche,isAlted);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Zeichenflaeche.Children.Clear();
            pkw.Clear();
            lkw.Clear();
            for (int i = 0; i < 10; i++)
            {
                pkw.Add(new PKW(Zeichenflaeche));
            }
            for (int i = 0; i < 10; i++)
            {
                lkw.Add(new LKW(Zeichenflaeche));
            }
            timer.Start();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                lkw.ForEach(x => x.links());
                pkw.ForEach(x => x.links());
            }
            else if (e.Key == Key.Right)
            {
                lkw.ForEach(x => x.Rechts());
                pkw.ForEach(x => x.Rechts());
            }
            else if  (e.Key == Key.Up)
            {

                isAlted = !isAlted;
            }
            


           
        }
    }
}
