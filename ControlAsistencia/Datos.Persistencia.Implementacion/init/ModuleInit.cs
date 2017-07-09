﻿using Datos.Persistencia.Core;
using Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.IoC;

namespace Datos.Persistencia.Implementacion
{
    [Export(typeof(IModule))]

    public class ModuleInit : IModule
    {
        public void Initialize(IRegisterModules register)
        {
            register.RegisterType<IContextoUnidadDeTrabajo, ContextoPrincipal>();

            register.RegisterType<IAsistenciaRepositorio, AsistenciaRepositorio>();
            register.RegisterType<IObraRepositorio, ObraRepositorio>();
            register.RegisterType<ITrabajadorObraRepositorio, TrabajadorObraRepositorio>();
            register.RegisterType<ITrabajadorRepositorio, TrabajadorRepositorio>();
            register.RegisterType<IPerfilRepositorio, PerfilRepositorio>();
        }
    }
}
