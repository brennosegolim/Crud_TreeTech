using Crud_TreeTech_API.DAO.TipoEquipamentoDAO;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Builder
{
    public class TipoEquipamentoBuilder
    {
        private readonly TipoEquipamento tipoEquipamento = new TipoEquipamento();
        private readonly ITipoEquipamentoDAO tipoEquipamentoDAO = new TipoEquipamentoDAO();

        //Nova instância do builder
        public static TipoEquipamentoBuilder NovoTipoEquipamento() => 
            new TipoEquipamentoBuilder();

        //Get's e Set's
        public TipoEquipamentoBuilder comIdTipoEquipamento(int IdTipoEquipamento)
        {
            tipoEquipamento.IdTipoEquipamento = IdTipoEquipamento;
            return this;
        }
        public TipoEquipamentoBuilder comNmTipoEquipamento(string nmTipoEquipamento)
        {
            tipoEquipamento.NomeTipoEquipamento = nmTipoEquipamento;
            return this;
        }
        public TipoEquipamentoBuilder comObservacao(string observacao)
        {
            tipoEquipamento.Observacao = observacao;
            return this;
        }

        /// <summary>
        /// Listar todos os registro da tabela de tipo de equipamento
        /// </summary>
        /// <returns></returns>
        public List<TipoEquipamentoDTO> ListaTodos()
        {
            return tipoEquipamentoDAO.ListarTodos();
        }

        /// <summary>
        /// Listar um registro da tabela tipo equipamento
        /// </summary>
        /// <returns></returns>
        public TipoEquipamentoDTO ListaUm()
        {
            return tipoEquipamentoDAO.ListarUm(tipoEquipamento);
        }

        /// <summary>
        /// Adicionar tipo de equipamento novo
        /// </summary>
        /// <returns></returns>
        public bool GravarTipoEquipamento()
        {
            return tipoEquipamentoDAO.Cadastrar(tipoEquipamento);
        }

        /// <summary>
        /// Atualizar o tipo de equipamento já existente
        /// </summary>
        /// <returns></returns>
        public bool AtualizarTipoEquipamento()
        {
            return tipoEquipamentoDAO.Atualizar(tipoEquipamento);
        }

        /// <summary>
        /// Deletar um registro da tabela de tipo de equipamento
        /// </summary>
        /// <returns></returns>
        public bool DeletarTipoEquipamento()
        {
            return tipoEquipamentoDAO.Deletar(tipoEquipamento);
        }
    }
}
