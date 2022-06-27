using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Abstracts;
using DAL.Repositories.Concretes;
using Ninject.Modules;
namespace BLL.Inject
{
    public class Service: NinjectModule
    {
        private string constring;
        public Service(string connection)
        {
            constring = connection;
        }

        public override void Load()
        {
            Bind<IUnitofWork>().To<UnitofWork>().InSingletonScope().WithConstructorArgument(constring);
        }
    }
}
