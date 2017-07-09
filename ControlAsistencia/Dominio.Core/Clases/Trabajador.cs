using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core
{
    public class Trabajador
    {
        public int TrabajadorID { get; set; }

        [StringLength(150)]
        public string nombre { get; set; }

        [StringLength(150)]
        public string apellido { get; set; }

        public Nullable<int> telefono { get; set; }

        [StringLength(100)]
        public string correo { get; set; }

        [StringLength(20)]
        public string password { get; set; }

        public Nullable<int> valorhra { get; set; }

        public Nullable<bool> disponible { get; set; }

        public Nullable<int> id_perfil { get; set; }

        public Nullable<bool> vigente { get; set; }

        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<TrabajadorObra> Trabajador_Obra { get; set; }
    }
}
