using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.AlarmeAtuadoDAO
{
    public interface IAlarmeAtuadoDAO
    {
        bool Cadastrar(AlarmesAtuados alarmesAtuados);
        bool Atualizar(AlarmesAtuados alarmesAtuados);
        bool Deletar(AlarmesAtuados alarmesAtuados);
        List<AlarmesAtuadosDTO> ListarTodos();
        List<AlarmesAtuadosDTO> rankingAlarmes();
        AlarmesAtuadosDTO ListarUm(AlarmesAtuados alarmesAtuados);
    }
}
