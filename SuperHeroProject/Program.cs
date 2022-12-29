using System;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using SuperHeroBackend.domain.repositories.interfaces;
using SuperHeroBackend.infrastructure.db;
using SuperHeroBackend.infrastructure.remote;
using SuperHeroProject.domain.interfaces;
using SuperHeroProject.domain.repositories;
using SuperHeroProject.domain.repositories.interfaces;

namespace SuperHeroProject
{
    public static class Program
    {
        public static StandardKernel Container;
        public static IMainRepository Repository;

        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                if (Kernel == null) return;

                Kernel.Bind<IMainApiService>().To<MainApiService>().InSingletonScope();
                Kernel.Bind<IUserDatabase>().To<UserDatabase>().InSingletonScope();
                Kernel.Bind<IHeroApiService>().To<HeroApiService>().InSingletonScope();
                Kernel.Bind<IMarketApiService>().To<MarketApiService>().InSingletonScope();

                Kernel.Bind<IMainRepository>().To<MainRepository>().InSingletonScope();
                Kernel.Bind<IHeroRepository>().To<HeroRepository>().InSingletonScope();
                Kernel.Bind<IMarketRepository>().To<MarketRepository>().InSingletonScope();
            }
        }

        private static Task Main()
        {
            Container = new StandardKernel(new MainModule());
            Console.WriteLine("[START]");
            var repository2 = Container.Get<IHeroRepository>();
            Repository = Container.Get<IMainRepository>();
            var repository3 = Container.Get<IMarketRepository>();
            var res = Repository.AddHeroToFavouritesById("600");
            // var res = repository3.AddHeroToMarket(new CustomHero("hello", "hello", "hello", "hello",
            //     new PowerStats(1, 2, 3)), 1000);
            if (res.IsSuccess)
            {
                Console.WriteLine("hello");
                var r = res;
                Console.WriteLine(r);
                // foreach (var h in r)
                // {
                //     Console.WriteLine(h.Name);
                // }
            }
            else
            {
                //Console.WriteLine(Utils.GetErrorMessage(res));
            }

            return Task.CompletedTask;
            // var result = repository.GetHeroById(45);
            // if (result.IsSuccess)
            // {
            //     var hero = result.Value;
            //
            //     Console.WriteLine(hero.Images);
            //     repository2.AddHeroToFavourites(hero);
            // }
            // else
            // {
            //     Console.WriteLine(result.Errors[0]);
            // }

            // Result.Try()
            //Console.WriteLine(result.Connections);
            //
            // var myuuid = Guid.NewGuid();
            // var customHero = new CustomHero(myuuid.ToString(), "hello", "guys", "");
            // Console.WriteLine(myuuid.ToString());

            // var firebase =
            //     new FirebaseClient("https://superheroproject-e3e22-default-rtdb.europe-west1.firebasedatabase.app/");
            // await firebase
            //     .Child("dinosaurs")
            //     .Child(customHero.Id)
            //     .PutAsync(customHero);

            // await firebase
            //     .Child("dinosaurs")
            //     .Child("087ec841-eaa5-4eb3-8b2c-b07504181650")
            //     .DeleteAsync();
            //Console.WriteLine(myHero.Name);

            // var stream = File.Open(@"C:\Users\Александр\Downloads\spiderman.jpg", FileMode.Open);
            // Console.WriteLine(stream.Length);
            // var result = repository.UploadPhoto(stream);
            // if (result.IsSuccess)
            // {
            //     Console.WriteLine(result);
            // }
            // var task = new FirebaseStorage("superheroproject-e3e22.appspot.com")
            //     .Child("random2")
            //     .Child("spiderman2.jpg")
            //     .PutAsync(stream);

// Track progress of the upload
            //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

// await the task to wait until upload completes and get the download url
            //var downloadUrl = await task;
            //Console.WriteLine(downloadUrl);

            //var stream = File.Open(@"C:\Users\you\file.png", FileMode.Open);
            //var firebase =
            //new FirebaseClient("https://superheroproject-e3e22-default-rtdb.europe-west1.firebasedatabase.app/");
            // add new item to list of data and let the client generate new key for you (done offline)
            // var dino1 = await firebase
            //     .Child("dinosaurs")
            //     .Child(hero.Name)
            //     //.AsRealtimeDatabase<>().Database
            //     .PostAsync(hero);
            //
            // var dinos = await firebase
            //     .Child("dinosaurs")
            //     .OrderByKey()
            //     .OnceAsync<Hero>();
            // foreach (var dino in dinos)
            // {
            //     var h = dino.Object;
            //     Console.WriteLine($"{dino.Key} is {h.Images}m high.");
            // }
            //
            // var auth = "ABCDE"; // your app secret
            // var firebaseClient = new FirebaseClient(
            //     "<URL>",
            //     new FirebaseOptions
            //     {
            //         AuthTokenAsyncFactory = () => Task.FromResult(auth). 
            //     });
            //
            //
        }
    }
}