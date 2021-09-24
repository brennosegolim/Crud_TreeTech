using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_TreeTech_Web2.Model
{
    public class AlarmesModel
    {
        public int IdAlarme { get; set; }
        public string NomeAlarme { get; set; }
        public int IdClassificacaoAlarme { get; set; }
        public int IdEquipamento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }
    }
}