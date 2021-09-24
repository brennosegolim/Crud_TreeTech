using Crud_TreeTech_API.Facade;
using Crud_TreeTech_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Controllers
{
    [ApiController]
    [Route("v1/Equipamentos")]
    public class EquipamentosController : ControllerBase
    {
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListaTodos()
        {
            return Ok(new EquipamentosFacade().ListarTodos());
        }

        [HttpGet]
        [Route("ListarUm")]
        public IActionResult ListaUm([FromQuery] int idEquipamento)
        {
            return Ok(new EquipamentosFacade().ListaUm(idEquipamento));
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] Equipamentos equipamentos)
        {
            return Ok(new EquipamentosFacade().CadastrarEquipamento(equipamentos.NomeEquipamento, equipamentos.NumeroSerie, equipamentos.IdTipoEquipamento, equipamentos.DataCadastro));
        }

        [HttpPost]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] Equipamentos equipamentos)
        {
            return Ok(new EquipamentosFacade().AtualizarEquipamento(equipamentos.IdEquipamento,equipamentos.NomeEquipamento, equipamentos.NumeroSerie, equipamentos.IdTipoEquipamento));
        }

        [HttpPost]
        [Route("Deletar")]
        public IActionResult Deletar([FromBody] Equipamentos equipamentos)
        {
            return Ok(new EquipamentosFacade().DeletarEquipamento(equipamentos.IdEquipamento));
        }
    }
}
