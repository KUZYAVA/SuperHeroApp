using SuperHeroBackend.domain.model.hero;
using SuperHeroBackend.domain.repositories.interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using SuperHeroProject.domain.model.hero;

namespace SuperHero.ViewModels
{
    class FavouritesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Hero> favouritesHeroes;
        public ObservableCollection<Hero> FavouriteHeroes
        {
            get { return favouritesHeroes; }
            set
            {
                favouritesHeroes = value;
                OnPropertyChanged("FavouriteHeroes");
            }
        }

        public IMainRepository repository = StandartVM.mainRepository;

        public FavouritesViewModel()
        {
            //FavouriteHeroes = new();
            var list = repository.GetAllHeroesFromFavourites();
            FavouriteHeroes = new();
            if (list.IsSuccess)
            {
                foreach (var hero in list.Value)
                    FavouriteHeroes.Add(hero);
            }

        }

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

        private RelayCommand deleteFromFavourites;
        public RelayCommand DeleteFromFavourites
        {
            get
            {
                return deleteFromFavourites ?? new RelayCommand(obj =>
                { DeleteFromFavouritesMethod(); }
                    );
            }
        }

        private void DeleteFromFavouritesMethod()
        {
            repository.DeleteHeroFromFavouritesById(SelectedHero.Id);
            favouritesHeroes.Remove(SelectedHero);
        }


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
                if (w.Name == "Favourites")
                    w.Close();
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
