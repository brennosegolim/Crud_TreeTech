using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_TreeTech_Web2.Model
{
    public class AlarmesAtuadosModel
    {
        public int IdAlarmesAtuados { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int IdAlarme { get; set; }
    }
}