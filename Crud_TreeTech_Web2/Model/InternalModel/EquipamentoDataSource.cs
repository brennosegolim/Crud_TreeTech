using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_TreeTech_Web2.Model.InternalModel
{
    public class EquipamentoDataSource
    {
        public int IdEquipamento { get; set; }
        public string NomeEquipamento { get; set; }
        public int NumeroSerie { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeTipoEquipamento { get; set; }
    }
}