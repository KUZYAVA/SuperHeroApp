using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ninject;
using System.Collections.ObjectModel;
using SuperHeroBackend.domain.model.hero;
using static SuperHeroProject.Program;
using SuperHeroBackend.domain.repositories.interfaces;
using SuperHero.Views;
using System.Windows;
using SuperHero;
using SuperHeroBackend;
using SuperHero.ViewModels;
using SuperHeroProject.domain.interfaces;
using SuperHeroProject.domain.model.hero;

namespace SuperHeroUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IHeroApiService apiRepository = StandartVM.mainApiRepository;
        private readonly IMainRepository repository = StandartVM.mainRepository;
        public ObservableCollection<Hero> Heroes { get; set; }
        

        private Hero selectedHero;
        public Hero SelectedHero
        {
            get { return selectedHero; }
            set
            {
                selectedHero = value;
                OnPropertyChanged("SelectedHero");
            }
        }


        public MainViewModel()
        {
            var heroes = apiRepository.GetAllHeroes();
            Heroes = new();
            foreach (var hero in heroes)
                Heroes.Add(hero);
        }

        #region Комнды открытия окон
        private RelayCommand openFavouritesWindow;
        public RelayCommand OpenFavouritesWindow
        {
            get
            {
                return openFavouritesWindow ?? new RelayCommand(obj =>
                    { OpenWindowWithOwnerProperties(new FavouritesWindow()); }
                    );
            }
        }

        private RelayCommand openCustomHeroesWindow;
        public RelayCommand OpenCustomHeroesWindow
        {
            get
            {
                return openCustomHeroesWindow ?? new RelayCommand(obj =>
                { OpenWindowWithOwnerProperties(new CustomHeroesWindow()); }
                    );
            }
        }
        #endregion

        #region Методы открытия новых окон по кнопкам
        private void OpenWindowWithOwnerProperties(Window newWindow)
        {
            newWindow.Owner = Application.Current.MainWindow;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newWindow.WindowState = Application.Current.MainWindow.WindowState;
            newWindow.Height = Application.Current.MainWindow.Height;
            newWindow.Width = Application.Current.MainWindow.Width;
            Application.Current.MainWindow.Hide();
            newWindow.ShowDialog();
            Application.Current.MainWindow.Show();

        }
        #endregion


        private RelayCommand addToFavourites;
        public RelayCommand AddToFavourites
        {
            get
            {
                return addToFavourites ?? new RelayCommand(obj =>
                { AddToFavouritesMethod(); }
                    );
            }
        }
        private void AddToFavouritesMethod()
        {
            repository.AddHeroToFavouritesById(selectedHero.Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
