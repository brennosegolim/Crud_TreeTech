using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.AlarmeDAO
{
    public interface IAlarmeDAO
    {
        bool Cadastrar(Alarmes alarmes);
        bool Atualizar(Alarmes alarmes);
        bool Deletar(Alarmes alarmes);
        List<AlarmesDTO> ListarTodos();
        AlarmesDTO ListarUm(Alarmes alarmes);
    }
}
