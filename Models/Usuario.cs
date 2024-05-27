using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vucoAPI.Enum;


namespace vucoAPI.obj.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Foto { get; set; }
        public TiposDeConta Tipo { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}