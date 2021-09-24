using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_TreeTech_Web2.Model
{
    public class EquipamentosModel
    {
        public int IdEquipamento { get; set; }
        public string NomeEquipamento { get; set; }
        public int NumeroSerie { get; set; }
        public int IdTipoEquipamento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeTipoEquipamento { get; set; }
    }
}