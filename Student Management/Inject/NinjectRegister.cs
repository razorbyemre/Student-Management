using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BLL.Interfaces;
using BLL;

namespace Student_Management.Inject
{
  public class NinjectRegister:NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCRUD>().To<Operations>();
        }
    }
}
