using Dominio.Core;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Datos.Persistencia.Core
{
    public class ContextoPrincipal : DbContext, IContextoUnidadDeTrabajo
    {
        public ContextoPrincipal() : base("DefaultConnection") { }

        //Atributo
        IDbSet<Casa> _casa;

        //Propiedad
        public IDbSet<Casa> Casas
        {
            get { return _casa ?? (_casa = base.Set<Casa>()); }
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

        public int Completar()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = false;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
