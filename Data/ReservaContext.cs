using Microsoft.EntityFrameworkCore;
using reservasjc.Models;

namespace reservasjc.Data
{
    public class ReservaContext : DbContext
    {
        public ReservaContext(DbContextOptions<ReservaContext> options) : base(options) { }

        public DbSet<Reserva> Reservas { get; set; }
    }
}

