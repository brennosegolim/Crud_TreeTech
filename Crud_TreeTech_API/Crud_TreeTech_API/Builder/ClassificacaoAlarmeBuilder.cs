using Crud_TreeTech_API.DAO.ClassificacaoAlarmeDAO;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Builder
{
    public class ClassificacaoAlarmeBuilder
    {
        private readonly ClassificacaoAlarmes classificacaoAlarmes = new ClassificacaoAlarmes();
        private readonly IClassificacaoAlarmeDAO classificacaoAlarmeDAO = new ClassificacaoAlarmeDAO();

        //Nova instância do builder
        public static ClassificacaoAlarmeBuilder NovaClassificaoAlarme() =>
            new ClassificacaoAlarmeBuilder();

        //Get's e Set's
        public ClassificacaoAlarmeBuilder comIdClassificacaoAlarme(int IdClassificacaoAlarme)
        {
            classificacaoAlarmes.IdClassificacaoAlarme = IdClassificacaoAlarme;
            return this;
        }
        public ClassificacaoAlarmeBuilder comNmClassificacaoAlarme(string nmClassificacaoAlarme)
        {
            classificacaoAlarmes.NomeClassificacaoAlarme = nmClassificacaoAlarme;
            return this;
        }
        public ClassificacaoAlarmeBuilder comEnviarEmail(bool enviarEmail)
        {
            classificacaoAlarmes.EnviarEmail = enviarEmail;
            return this;
        }
        public ClassificacaoAlarmeBuilder comObservacao(string observacao)
        {
            classificacaoAlarmes.Observacao = observacao;
            return this;
        }

        /// <summary>
        /// Listar todos os registro da tabela de classificação de alarme
        /// </summary>
        /// <returns></returns>
        public List<ClassificacaoAlarmesDTO> ListaTodos()
        {
            return classificacaoAlarmeDAO.ListarTodos();
        }

        /// <summary>
        /// Listar um registro da tabela classificação de alarme
        /// </summary>
        /// <returns></returns>
        public ClassificacaoAlarmesDTO ListaUm()
        {
            return classificacaoAlarmeDAO.ListarUm(classificacaoAlarmes);
        }

        /// <summary>
        /// Adicionar classificação de alarme nova
        /// </summary>
        /// <returns></returns>
        public bool GravarClassificacaoAlarme()
        {
            return classificacaoAlarmeDAO.Cadastrar(classificacaoAlarmes);
        }

        /// <summary>
        /// Atualizar a classificação de alarme já existente
        /// </summary>
        /// <returns></returns>
        public bool AtualizarClassificacaoAlarme()
        {
            return classificacaoAlarmeDAO.Atualizar(classificacaoAlarmes);
        }

        /// <summary>
        /// Deletar um registro da tabela de classificação de alarme
        /// </summary>
        /// <returns></returns>
        public bool DeletarClassificaoAlarme()
        {
            return classificacaoAlarmeDAO.Deletar(classificacaoAlarmes);
        }
    }
}
