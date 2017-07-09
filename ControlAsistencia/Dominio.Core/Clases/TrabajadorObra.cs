using System;

namespace Dominio.Core
{
    public class TrabajadorObra
    {
        public int TrabajadorObraID { get; set; }
        public Nullable<int> id_trabajador { get; set; }
        public Nullable<int> id_obra { get; set; }
        public Nullable<bool> vigente { get; set; }
    }
}
