using SuperHero.ViewModels;
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
using System.Windows.Shapes;

namespace SuperHero.Views
{
    /// <summary>
    /// Логика взаимодействия для CustomHeroesWindow.xaml
    /// </summary>
    public partial class CustomHeroesWindow : Window
    {
        public CustomHeroesWindow()
        {
            InitializeComponent();
            DataContext = new CustomsViewModel();
        }
    }
}
