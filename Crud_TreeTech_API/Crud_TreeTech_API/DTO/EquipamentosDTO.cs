using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DTO
{
    public class EquipamentosDTO
    {
        public int IdEquipamento { get; set; }
        public string NomeEquipamento { get; set; }
        public int NumeroSerie { get; set; }
        public int IdTipoEquipamento { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
