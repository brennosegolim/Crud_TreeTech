using Crud_TreeTech_API.DAO.AlarmeAtuadoDAO;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Builder
{
    public class AlarmeAtuadoBuilder
    {
        private readonly AlarmesAtuados alarmesAtuados = new AlarmesAtuados();
        private readonly IAlarmeAtuadoDAO alarmeAtuadoDAO = new AlarmeAtuadoDAO();

        //Nova instância do builder
        public static AlarmeAtuadoBuilder NovoAlarmeAtuado() =>
            new AlarmeAtuadoBuilder();

        //Get's e Set's
        public AlarmeAtuadoBuilder comIdAlarmeAtuado(int idAlarmeAtuado)
        {
            alarmesAtuados.IdAlarmeAtuado = idAlarmeAtuado;
            return this;
        }

        public AlarmeAtuadoBuilder comDtEntrada(DateTime dtEntrada)
        {
            alarmesAtuados.DataEntrada = dtEntrada;
            return this;
        }

        public AlarmeAtuadoBuilder comDtSaida(DateTime dtSaida)
        {
            alarmesAtuados.DataSaida = dtSaida;
            return this;
        }

        public AlarmeAtuadoBuilder comIdAlarme(int idAlarme)
        {
            alarmesAtuados.IdAlarme = idAlarme;
            return this;
        }

        /// <summary>
        /// Listar todos os registro da tabela de alarmes atuados
        /// </summary>
        /// <returns></returns>
        public List<AlarmesAtuadosDTO> ListaTodos()
        {
            return alarmeAtuadoDAO.ListarTodos();
        }

        /// <summary>
        /// Listar um registro da tabela de alarmes atuados
        /// </summary>
        /// <returns></returns>
        public AlarmesAtuadosDTO ListaUm()
        {
            return alarmeAtuadoDAO.ListarUm(alarmesAtuados);
        }

        /// <summary>
        /// Adicionar alarme atuado novo
        /// </summary>
        /// <returns></returns>
        public bool GravarAlarmeAtuado()
        {
            return alarmeAtuadoDAO.Cadastrar(alarmesAtuados);
        }

        /// <summary>
        /// Atualizar registro de alarme atuado
        /// </summary>
        /// <returns></returns>
        public bool AtualizarAlarmeAtuado()
        {
            return alarmeAtuadoDAO.Atualizar(alarmesAtuados);
        }

        /// <summary>
        /// Deletar um registro da tabela de alarmes atuados
        /// </summary>
        /// <returns></returns>
        public bool DeletarAlarmeAtuado()
        {
            return alarmeAtuadoDAO.Deletar(alarmesAtuados);
        }
    }
}
