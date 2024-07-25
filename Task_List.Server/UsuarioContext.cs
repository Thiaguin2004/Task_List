using Microsoft.EntityFrameworkCore;

namespace Task_List.Server
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public UsuarioContext(DbContextOptions<UsuarioContext> options) :
            base(options)
        {
        }
    }
}
