using System;
using Dominio.Core;
using System.Data.Entity;

namespace Datos.Persistencia.Core
{
    public interface IContextoUnidadDeTrabajo : IUnidadDeTrabajo, IDisposable
    {
        IDbSet<Casa> Casas { get; }

        IDbSet<Entidad> Set<Entidad>() where Entidad : class;

        void Attach<Entidad>(Entidad item) where Entidad : class;

        void SetModified<Entidad>(Entidad item) where Entidad : class;
    }
}
