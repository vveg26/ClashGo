using ClashGo.Model;
using ClashGo.ViewModel.Command;
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

namespace ClashGo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
           // this.DataContext = new ConfigYml();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        //  this.Visibility = Visibility.Collapsed;
        }

        private void list(object sender, RoutedEventArgs e)
        {

            //  this.Visibility = Visibility.Collapsed;
        }

    }
}
