using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vucoAPI.Enum;
using vucoAPI.obj.Models;


namespace vucoAPI.obj.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
        public StatusProdutos Status{ get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}