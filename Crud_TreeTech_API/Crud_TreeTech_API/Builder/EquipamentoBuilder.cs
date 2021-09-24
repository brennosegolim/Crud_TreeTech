using Crud_TreeTech_API.DAO.EquipamentoDAO;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Builder
{
    public class EquipamentoBuilder
    {
        private readonly Equipamentos equipamento = new Equipamentos();
        private readonly IEquipamentoDAO equipamentoDAO = new EquipamentoDAO();

        //Nova instância do builder
        public static EquipamentoBuilder NovoEquipamento() =>
            new EquipamentoBuilder();

        //Get's e Set's
        public EquipamentoBuilder comIdEquipamento(int IdEquipamento)
        {
            equipamento.IdEquipamento = IdEquipamento;
            return this;
        }
        public EquipamentoBuilder comNmEquipamento(string nmEquipamento)
        {
            equipamento.NomeEquipamento = nmEquipamento;
            return this;
        }
        public EquipamentoBuilder comNoSerie(int noSerie)
        {
            equipamento.NumeroSerie = noSerie;
            return this;
        }

        public EquipamentoBuilder comIdTipoEquipamento(int idTipoEquipamento)
        {
            equipamento.IdTipoEquipamento = idTipoEquipamento;
            return this;
        }

        public EquipamentoBuilder comDataCdastro(DateTime dtCadastro)
        {
            equipamento.DataCadastro = dtCadastro;
            return this;
        }

        /// <summary>
        /// Listar todos os registro da tabela de equipamentos
        /// </summary>
        /// <returns></returns>
        public List<EquipamentosDTO> ListaTodos()
        {
            return equipamentoDAO.ListarTodos();
        }

        /// <summary>
        /// Listar um registro da tabela tipo equipamento
        /// </summary>
        /// <returns></returns>
        public EquipamentosDTO ListaUm()
        {
            return equipamentoDAO.ListarUm(equipamento);
        }

        /// <summary>
        /// Adicionar tipo de equipamento novo
        /// </summary>
        /// <returns></returns>
        public bool GravarEquipamento()
        {
            return equipamentoDAO.Cadastrar(equipamento);
        }

        /// <summary>
        /// Atualizar o tipo de equipamento já existente
        /// </summary>
        /// <returns></returns>
        public bool AtualizarEquipamento()
        {
            return equipamentoDAO.Atualizar(equipamento);
        }

        /// <summary>
        /// Deletar um registro da tabela de tipo de equipamento
        /// </summary>
        /// <returns></returns>
        public bool DeletarEquipamento()
        {
            return equipamentoDAO.Deletar(equipamento);
        }
    }
}
