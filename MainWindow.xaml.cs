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
using System.Threading;
using System.Windows.Threading;

namespace NoidClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           

        }
        
        public double pizzas = 0;
        private void newcookie(object sender, RoutedEventArgs e)
        {
            
                
            amountofP.Text = Convert.ToInt32(pizzas).ToString();
            if (cpsamount == 1)
            {
                pizzas+=1;
            }
            else
            {
                pizzas+=10;
            }
            if (pizzas >= 11&&btnclick!=5)
            {
                noid.IsEnabled=true;
                noid.Visibility=Visibility.Visible;
            }
            if (pizzas >= 100)
            {
                cps.IsEnabled=true;
                cps.Visibility=Visibility.Visible;
            }
            if (pizzas >= 1000)
            {
                noidhelper.IsEnabled = true;
                noidhelper.Visibility = Visibility.Visible;
            }
        }
        int noidishelping = 1;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt =new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
            
        }
        private int increment = 0;
        public int btnclick = 1;
        private void Dt_Tick(object sender, EventArgs e)
        {
            increment++;
            TimeLabel.FontSize = 20;
            TimeLabel.Margin=new Thickness(20,0,0,0);
            TimeLabel.Content = increment.ToString();
            
            if (noidishelping == 1)
            {
                if ((increment >= 10) && (btnclick == 5))
                {

                    pizzas = pizzas * 1.5;
                    int a = Convert.ToInt32(pizzas);
                    amountofP.Text = a.ToString();

                    increment = 0;

                }
            }
            else
            {
                if ((increment >= 5) && (btnclick == 5))
                {

                    pizzas = pizzas * 1.5;
                    int a = Convert.ToInt32(pizzas);
                    amountofP.Text = a.ToString();

                    increment = 0;

                }
            }
            
        }

        private void noidclicked(object sender, RoutedEventArgs e)
        {
            TimeLabel.Visibility = Visibility.Visible;
            TimeLabel.IsEnabled = true;
            
            pizzas = pizzas * 1.5;
            int a = Convert.ToInt32(pizzas);        
            amountofP.Text = a.ToString();
            amountofP.TextAlignment = TextAlignment.Center;
            btnclick = 5;
            noid.Background = new SolidColorBrush(Colors.Gray);
            noid.Content = "";
            MessageBox.Show("Multiplies pizzas by 1.5 every 10 seconds!");
        }
        public int cpsamount = 1;
        private void cpsclick(object sender, RoutedEventArgs e)
        {
            cpsamount = 2;
            cps.IsEnabled = false;
            cps.Background = new SolidColorBrush(Colors.Gray);
            cps.Content = "Bought";
            MessageBox.Show("Clicks are 10X more effective!");
        }

        private void noidclick(object sender, RoutedEventArgs e)
        {
            noidishelping = 2;
            noidhelper.IsEnabled = false;
            noidhelper.Background = new SolidColorBrush(Colors.Gray);
            noidhelper.Content = "Bought";
            Padding = new Thickness(20);
            MessageBox.Show("Half the time the 1.5X Bonus Takes to recharge!");
        }

        private void Cosmetics_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow window = new NavigationWindow();
            window.Source = new Uri("Cosmetics.xaml", UriKind.Relative);
            window.Show();
            this.Visibility = Visibility.Hidden;
        }
    } 
}
