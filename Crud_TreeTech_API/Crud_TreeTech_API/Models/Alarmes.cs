using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Models
{
    public class Alarmes
    {
        [Key]
        public int IdAlarme { get; set; }
        public string NomeAlarme { get; set; }
        public int IdClassificacaoAlarme { get; set; }
        public int IdEquipamento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }
    }
}
