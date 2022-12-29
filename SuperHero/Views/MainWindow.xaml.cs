using SuperHero.Views;
using SuperHeroUI.ViewModels;
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

namespace SuperHeroUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var w = new FavouritesWindow();
        //    w.Height = ActualHeight;
        //    w.Width = ActualWidth;
        //    w.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        //    w.Owner = this;
        //    w.Show();
        //    w.WindowState = this.WindowState;
        //    this.Hide();
        //}
    }
}
