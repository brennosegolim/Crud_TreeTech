using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Models
{
    public class ClassificacaoAlarmes
    {
        [Key]
        public int IdClassificacaoAlarme { get; set; }
        public string NomeClassificacaoAlarme { get; set; }
        public bool EnviarEmail { get; set; }
        public string Observacao { get; set; }
    }
}
