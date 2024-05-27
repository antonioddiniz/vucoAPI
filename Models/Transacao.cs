using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vucoAPI.Enum;
using vucoAPI.obj.Models;

namespace vucoAPI.obj.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public int IdUsuario1 { get; set; }
        public Usuario Usuario1 { get; set; }
        public int IdUsuario2 { get; set; }
        public Usuario Usuario2 { get; set; }
        public List<Produto> ProdutosUsuario1 { get; set; }
        public List<Produto> ProdutosUsuario2 { get; set; }
        public DateTime DataTransacao { get; set; }
        public StatusTransacao Status { get; set; }
    }
}
