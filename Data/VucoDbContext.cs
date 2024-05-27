using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vucoAPI.obj.Models;

namespace vucoAPI.Data
{
    public class VucoDbContext : DbContext
    {
        public VucoDbContext(DbContextOptions<VucoDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        
}
}