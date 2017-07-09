using Dominio.Core;
using System;
using System.Data.Entity;

namespace Datos.Persistencia.Core
{
    public interface IContextoUnidadDeTrabajo : IUnidadDeTrabajo, IDisposable
    {
        IDbSet<Asistencia> Asistencias { get; }
        IDbSet<Obra> Obras { get; }
        IDbSet<Perfil> Perfiles { get; }
        IDbSet<Trabajador> Trabajadores { get; }
        IDbSet<TrabajadorObra> TrabajadorObras { get; }

        IDbSet<Entidad> Set<Entidad>() where Entidad : class;
        void Attach<Entidad>(Entidad item) where Entidad : class;   
        void SetModified<Entidad>(Entidad item) where Entidad : class;
    }
}
