using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DTO
{
    public class ClassificacaoAlarmesDTO
    {
        public int IdClassificacaoAlarme { get; set; }
        public string NomeClassificacaoAlarme { get; set; }
        public bool EnviarEmail { get; set; }
        public string Observacao { get; set; }
    }
}
