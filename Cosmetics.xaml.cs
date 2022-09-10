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

namespace NoidClicker
{
    /// <summary>
    /// Interaction logic for Cosmetics.xaml
    /// </summary>
    public partial class Cosmetics : Page
    {
        double pizzas1;
        public Cosmetics()
        {
            InitializeComponent();
        }
        public Cosmetics(double pizzas) : this()
        {
            pizzas1 = pizzas;
            pizzas1 -= 1;
            this.Loaded += new RoutedEventHandler(Cosmetics_Loaded);
        }
        int purchased = 0;
        void Cosmetics_Loaded(object sender, RoutedEventArgs e)
        {
            test.Text = "Pizzas: " + pizzas1;
        }
        private void purchasenoid(object sender, RoutedEventArgs e)
        {
            if (pizzas1 >= 10000)
            {
                pizzas1 = 10000;
                purchased += 1;
                NoidPoster.IsHitTestVisible = false;
                NoidPoster.Opacity = .30;
            }
            else
            {
                pizzas1 = 0;
            }
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Visibility = Visibility.Visible;
            Window win = (Window)this.Parent;
            win.Close();
        }
    }
}
