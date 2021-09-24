using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DTO
{
    public class AlarmesAtuadosDTO
    {
        public int IdAlarmesAtuados { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int IdAlarme { get; set; }
    }
}
