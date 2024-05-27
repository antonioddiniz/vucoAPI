using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vucoAPI.obj.Models;

namespace vucoAPI.obj.Models
{
    public class TransacaoProduto
    {
    public int TransacaoId { get; set; }
    public Transacao Transacao { get; set; }

    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
}


    }
