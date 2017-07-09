using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Core
{
    public class ObraDTO
    {
        [Key]
        public int obraID { get; set; }

        [StringLength(150)]
        public string nombre { get; set; }
        public Nullable<bool> vigente { get; set; }

    }
}
