using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Core
{
    public class PerfilDTO
    {
        [Key]
        public int perfilID { get; set; }

        [StringLength(150)]
        public string nombre { get; set; }

        [StringLength(150)]
        public string descripcion { get; set; }

        public Nullable<bool> vigente { get; set; }
    }
}
