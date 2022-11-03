using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio_Projeto_MVC_DotNet.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}