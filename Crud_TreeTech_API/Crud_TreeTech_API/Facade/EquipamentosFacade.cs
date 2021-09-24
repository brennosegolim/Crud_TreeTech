using Crud_TreeTech_API.Builder;
using Crud_TreeTech_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Facade
{
    public class EquipamentosFacade
    {
        public List<EquipamentosDTO> ListarTodos()
        {
            return EquipamentoBuilder.NovoEquipamento().ListaTodos();
        }

        public EquipamentosDTO ListaUm(int idEquipamento)
        {
            return EquipamentoBuilder.NovoEquipamento().comIdEquipamento(idEquipamento).ListaUm();
        }

        public string CadastrarEquipamento(string nmEquipamento,int noSerie,int idTipoEquipamento,DateTime dtCadastro)
        {
            if (EquipamentoBuilder.NovoEquipamento().comNmEquipamento(nmEquipamento).comNoSerie(noSerie).comIdTipoEquipamento(idTipoEquipamento).comDataCdastro(dtCadastro).GravarEquipamento())
            {
                return "Novo Equipamento Cadastrado com Sucesso!";
            }
            else
            {
                return "Erro durante o Cadastro de Equipamento!";
            }
        }

        public string AtualizarEquipamento(int idEquipamento, string nmEquipamento, int noSerie, int idTipoEquipamento)
        {
            if (EquipamentoBuilder.NovoEquipamento().comIdEquipamento(idEquipamento).comNmEquipamento(nmEquipamento).comNoSerie(noSerie).comIdTipoEquipamento(idTipoEquipamento).AtualizarEquipamento())
            {
                return "Equipamento atualizado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de atualização de equipamento";
            }
        }

        public string DeletarEquipamento(int idEquipamento)
        {
            if (EquipamentoBuilder.NovoEquipamento().comIdEquipamento(idEquipamento).DeletarEquipamento())
            {
                return "Equipamento deletado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de remoção de equipamento";
            }
        }
    }
}
