using Ninject;
using SuperHeroBackend.domain.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHeroProject.domain.interfaces;
using static SuperHeroProject.Program;

namespace SuperHero.ViewModels
{
    public static class StandartVM
    {
        public static StandardKernel container = new StandardKernel(new MainModule());
        public static IMainRepository mainRepository = container.Get<IMainRepository>();
        public static IHeroApiService mainApiRepository = container.Get<IHeroApiService>();
    }
}
