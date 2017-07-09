using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Core
{
    public class AsistenciaDTO
    {
        [Key]
        public int AsistenciaID { get; set; }
        public Nullable<int> id_trabajador_obra { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fecha { get; set; }

        public Nullable<System.TimeSpan> hora { get; set; }

        public Nullable<bool> vigente { get; set; }
    }
}
