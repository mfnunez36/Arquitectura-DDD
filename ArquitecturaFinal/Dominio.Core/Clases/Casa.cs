using System.ComponentModel.DataAnnotations;

namespace Dominio.Core
{
    public class Casa
    {
        public int CasaID { get; set; }

        [Required]//TABLA DE BASE DE DATOS ESTE CAMPO SEA NOT NULL
        public int Numero { get; set; }

        [Required, StringLength(300)]
        public string Calle { get; set; }

        [Required]
        public int NumeroHabitaciones { get; set; }

        [Required]
        public int NumeroBaños { get; set; }

        [Required]
        public int Pisos { get; set; }

        [Required]
        public decimal MetrosCuadrados { get; set; }
    }
}
