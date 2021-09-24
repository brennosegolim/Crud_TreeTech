using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DTO
{
    public class AlarmesDTO
    {
        public int IdAlarme { get; set; }
        public string NomeAlarme { get; set; }
        public int IdClassificacaoAlarme { get; set; }
        public int IdEquipamento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }
    }
}
