using SuperHeroUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperHero.ViewModels
{
    class AuthorizationViewModel
    {
        private RelayCommand authorization;
        public RelayCommand Authorization
        {
            get
            {
                return authorization ?? new RelayCommand(obj =>
                { Authorize(); });
            }
        }


        private void Authorize()
        {
            var mainWindow = new MainWindow();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
