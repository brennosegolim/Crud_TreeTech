using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Models
{
    public class AlarmesAtuados
    {
        [Key]
        public int IdAlarmeAtuado { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int IdAlarme { get; set; }
    }
}
