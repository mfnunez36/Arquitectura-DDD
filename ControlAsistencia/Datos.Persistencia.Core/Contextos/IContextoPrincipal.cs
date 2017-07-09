using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Persistencia.Core
{
    public class ContextoPrincipal : DbContext, IContextoUnidadDeTrabajo
    {
        public ContextoPrincipal() : base("DefaultConnection") { }

        IDbSet<Asistencia> _asistencia;
        IDbSet<Obra> _obra;
        IDbSet<Perfil> _perfil;
        IDbSet<Trabajador> _trabajador;
        IDbSet<TrabajadorObra> _trabajadorObra;



        public IDbSet<Asistencia> Asistencias
        {
            get { return _asistencia ?? (_asistencia = base.Set<Asistencia>()); }
        }

        public IDbSet<Obra> Obras
        {
            get { return _obra ?? (_obra = base.Set<Obra>()); }
        }

        public IDbSet<Perfil> Perfiles
        {
            get { return _perfil ?? (_perfil = base.Set<Perfil>()); }
        }

        public IDbSet<Trabajador> Trabajadores
        {
            get { return _trabajador ?? (_trabajador = base.Set<Trabajador>()); }
        }

        public IDbSet<TrabajadorObra> TrabajadorObras
        {
            get { return _trabajadorObra ?? (_trabajadorObra = base.Set<TrabajadorObra>()); }
        }

        public new IDbSet<Entidad> Set<Entidad>() where Entidad : class
        {
            return base.Set<Entidad>();
        }

        public void Attach<Entidad>(Entidad item) where Entidad : class
        {
            if (Entry(item).State == EntityState.Detached)
            {
                base.Set<Entidad>().Attach(item);
            }
        }

        public void SetModified<Entidad>(Entidad item) where Entidad : class
        {
            Entry(item).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = false;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public int Completar()
        {
            return base.SaveChanges();
        }
    }
}
