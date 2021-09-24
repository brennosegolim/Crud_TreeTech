using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Models
{
    public class TipoEquipamento
    {
        [Key]
        public int IdTipoEquipamento { get; set; }
        public string NomeTipoEquipamento { get; set; }
        public string Observacao { get; set; }
    }
}
