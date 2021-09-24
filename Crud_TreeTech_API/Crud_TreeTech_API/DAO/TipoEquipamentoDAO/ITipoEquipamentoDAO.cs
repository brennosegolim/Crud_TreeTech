using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.TipoEquipamentoDAO
{
    public interface ITipoEquipamentoDAO
    {
        bool Cadastrar(TipoEquipamento tipoEquipamento);
        bool Atualizar(TipoEquipamento tipoEquipamento);
        bool Deletar(TipoEquipamento tipoEquipamento);
        List<TipoEquipamentoDTO> ListarTodos();
        TipoEquipamentoDTO ListarUm(TipoEquipamento tipoEquipamento);
    }
}
