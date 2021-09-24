using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_TreeTech_Web2.Model
{
    public class ClassificacaoAlarmesModel
    {
        public int IdClassificacaoAlarme { get; set; }
        public string NomeClassificacaoAlarme { get; set; }
        public bool EnviarEmail { get; set; }
        public string Observacao { get; set; }
    }
}