using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.EquipamentoDAO
{
    public interface IEquipamentoDAO
    {
        bool Cadastrar(Equipamentos equipamento);
        bool Atualizar(Equipamentos equipamento);
        bool Deletar(Equipamentos equipamento);
        List<EquipamentosDTO> ListarTodos();
        EquipamentosDTO ListarUm(Equipamentos equipamento);
    }
}
