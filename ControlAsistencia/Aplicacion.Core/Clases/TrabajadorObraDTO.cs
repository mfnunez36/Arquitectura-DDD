using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Core
{
    public class TrabajadorObraDTO
    {
        [Key]
        public int trabajadorObraID { get; set; }
        public Nullable<int> id_trabajador { get; set; }
        public Nullable<int> id_obra { get; set; }
        public Nullable<bool> vigente { get; set; }
    }
}
