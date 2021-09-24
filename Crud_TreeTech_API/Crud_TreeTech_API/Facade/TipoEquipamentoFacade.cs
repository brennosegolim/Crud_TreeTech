using Crud_TreeTech_API.Builder;
using Crud_TreeTech_API.DAO.TipoEquipamentoDAO;
using Crud_TreeTech_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Facade
{
    public class TipoEquipamentoFacade
    {
        public List<TipoEquipamentoDTO> ListarTodos()
        {
            return TipoEquipamentoBuilder.NovoTipoEquipamento().ListaTodos();
        }

        public TipoEquipamentoDTO ListaUm(int idTipoEquipamento)
        {
            return TipoEquipamentoBuilder.NovoTipoEquipamento().comIdTipoEquipamento(idTipoEquipamento).ListaUm();
        }

        public string CadastrarTipoEquipamento(string nmTipoEquipamento, string observacao)
        {
            if (TipoEquipamentoBuilder.NovoTipoEquipamento().comNmTipoEquipamento(nmTipoEquipamento).comObservacao(observacao).GravarTipoEquipamento())
            {
                return "Tipo de equipamento cadastrado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de cadastro de tipo de equipamento";
            }
        }

        public string AtualizarTipoEquipamento(int idTipoEquipamento, string nmTipoEquipamento, string observacao)
        {
            if (TipoEquipamentoBuilder.NovoTipoEquipamento().comIdTipoEquipamento(idTipoEquipamento).comNmTipoEquipamento(nmTipoEquipamento).comObservacao(observacao).AtualizarTipoEquipamento())
            {
                return "Tipo de equipamento atualizado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de atualização de tipo de equipamento";
            }
        }

        public string DeletarTipoEquipamento(int idTipoEquipamento)
        {
            if (TipoEquipamentoBuilder.NovoTipoEquipamento().comIdTipoEquipamento(idTipoEquipamento).DeletarTipoEquipamento())
            {
                return "Tipo de equipamento deletado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de remoção de tipo de equipamento";
            }
        }
    }
}
