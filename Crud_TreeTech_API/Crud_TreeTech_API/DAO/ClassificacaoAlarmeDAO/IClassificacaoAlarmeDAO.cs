using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.ClassificacaoAlarmeDAO
{
    public interface IClassificacaoAlarmeDAO
    {
        bool Cadastrar(ClassificacaoAlarmes classificacaoAlarmes);
        bool Atualizar(ClassificacaoAlarmes classificacaoAlarmes);
        bool Deletar(ClassificacaoAlarmes classificacaoAlarmes);
        List<ClassificacaoAlarmesDTO> ListarTodos();
        ClassificacaoAlarmesDTO ListarUm(ClassificacaoAlarmes classificacaoAlarmes);
    }

}
