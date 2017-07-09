using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core
{
    public class Obra
    {
        public int ObraID { get; set; }

        [StringLength(150)]
        public string nombre { get; set; }

        public Nullable<bool> vigente { get; set; }

        public virtual ICollection<TrabajadorObra> Trabajador_Obra { get; set; }
    }
}
