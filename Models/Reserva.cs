    using System;
    using System.ComponentModel.DataAnnotations;

    namespace reservasjc.Models
    {
        public class Reserva
        {
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public required string NombreCliente { get; set; }

            [Required]
            public DateTime FechaReserva { get; set; }

            [Range(1, 20)]
            public int NumeroPersonas { get; set; }

            [StringLength(200)]
            public required string Observaciones { get; set; }
        }
    }
