using Microsoft.EntityFrameworkCore;
using ProyectoRoot.Controllers.Models;

namespace ProyectoRoot.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// Se indica a Entity Framework crear esta tabla
        /// </summary>
        public DbSet<Contacto> Contacto { get; set; }
    }
}
