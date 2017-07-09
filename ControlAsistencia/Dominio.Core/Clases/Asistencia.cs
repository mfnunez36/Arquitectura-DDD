using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core
{
    public class Asistencia
    {
        public int AsistenciaID { get; set; }
        public Nullable<int> id_trabajador_obra { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fecha { get; set; }

        public Nullable<System.TimeSpan> hora { get; set; }

        public Nullable<bool> vigente { get; set; }

        public virtual TrabajadorObra TrabajadorObra { get; set; }
        
    }
}
