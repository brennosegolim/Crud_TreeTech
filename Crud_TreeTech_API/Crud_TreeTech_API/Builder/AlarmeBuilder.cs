using Crud_TreeTech_API.DAO.AlarmeDAO;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Builder
{
    public class AlarmeBuilder
    {
        private readonly Alarmes alarmes = new Alarmes();
        private readonly IAlarmeDAO alarmeDAO = new AlarmeDAO();

        //Nova instância do builder
        public static AlarmeBuilder NovoAlarme() =>
            new AlarmeBuilder();

        //Get's e Set's
        public AlarmeBuilder comIdAlarme(int idAlarme)
        {
            alarmes.IdAlarme = idAlarme;
            return this;
        }
        public AlarmeBuilder comNmAlarme(string nmAlarme)
        {
            alarmes.NomeAlarme = nmAlarme;
            return this;
        }
        public AlarmeBuilder comIdClassificacaoAlarme(int idClassificacaoAlarme)
        {
            alarmes.IdClassificacaoAlarme = idClassificacaoAlarme;
            return this;
        }
        public AlarmeBuilder comIdEquipamento(int idEquipamento)
        {
            alarmes.IdEquipamento = idEquipamento;
            return this;
        }

        public AlarmeBuilder comDtCadastro(DateTime dtCadastro)
        {
            alarmes.DataCadastro = dtCadastro;
            return this;
        }

        public AlarmeBuilder comStatus(bool status)
        {
            alarmes.Status = status;
            return this;
        }

        /// <summary>
        /// Listar todos os registro da tabela de classificação de alarme
        /// </summary>
        /// <returns></returns>
        public List<AlarmesDTO> ListaTodos()
        {
            return alarmeDAO.ListarTodos();
        }

        /// <summary>
        /// Listar um registro da tabela classificação de alarme
        /// </summary>
        /// <returns></returns>
        public AlarmesDTO ListaUm()
        {
            return alarmeDAO.ListarUm(alarmes);
        }

        /// <summary>
        /// Adicionar classificação de alarme nova
        /// </summary>
        /// <returns></returns>
        public bool GravarAlarme()
        {
            return alarmeDAO.Cadastrar(alarmes);
        }

        /// <summary>
        /// Atualizar a classificação de alarme já existente
        /// </summary>
        /// <returns></returns>
        public bool AtualizarAlarme()
        {
            return alarmeDAO.Atualizar(alarmes);
        }

        /// <summary>
        /// Deletar um registro da tabela de classificação de alarme
        /// </summary>
        /// <returns></returns>
        public bool DeletarAlarme()
        {
            return alarmeDAO.Deletar(alarmes);
        }
    }
}
