using SuperHeroBackend.domain.model.hero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SuperHeroProject.domain.model.hero;

namespace SuperHero.ViewModels
{
    class CustomsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Hero> CustomHeroes { get; set; }


        private RelayCommand backToMainWindow;
        public RelayCommand BackToMainWindow
        {
            get
            {
                return backToMainWindow ?? new RelayCommand(obj =>
                { ShowMainWindow(); }
                    );
            }
        }

        private void ShowMainWindow()
        {
            Application.Current.MainWindow.Show();
            foreach (Window w in Application.Current.Windows)
                if (w.Name == "Customs")
                    w.Close();
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
