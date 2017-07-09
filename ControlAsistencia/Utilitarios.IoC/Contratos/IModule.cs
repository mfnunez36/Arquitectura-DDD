using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.IoC
{
    public interface IModule
    {
        void Initialize(IRegisterModules register);
    }
}
