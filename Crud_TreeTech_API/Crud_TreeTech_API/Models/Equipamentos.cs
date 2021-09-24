using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Models
{
    public class Equipamentos
    {
        [Key]
        public int IdEquipamento { get; set; }
        public string NomeEquipamento { get; set; }
        public int NumeroSerie { get; set; }
        public int IdTipoEquipamento { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
