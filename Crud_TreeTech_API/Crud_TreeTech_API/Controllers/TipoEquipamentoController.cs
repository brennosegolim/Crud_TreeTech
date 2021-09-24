using Crud_TreeTech_API.Facade;
using Crud_TreeTech_API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Crud_TreeTech_API.Controllers
{

    [ApiController]
    [Route("v1/TipoEquipamento")]
    public class TipoEquipamentoController : ControllerBase
    {
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListaTodos()
        {
            return Ok(new TipoEquipamentoFacade().ListarTodos());
        }

        [HttpGet]
        [Route("ListarUm")]
        public IActionResult ListaUm([FromQuery] int idTIpoEquipamento)
        {
            return Ok(new TipoEquipamentoFacade().ListaUm(idTIpoEquipamento));
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] TipoEquipamento parametros)
        {
            return Ok(new TipoEquipamentoFacade().CadastrarTipoEquipamento(parametros.NomeTipoEquipamento, parametros.Observacao));
        }

        [HttpPost]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] TipoEquipamento parametros)
        {
            return Ok(new TipoEquipamentoFacade().AtualizarTipoEquipamento(parametros.IdTipoEquipamento, parametros.NomeTipoEquipamento, parametros.Observacao));
        }

        [HttpPost]
        [Route("Deletar")]
        public IActionResult Deletar([FromBody] TipoEquipamento parametros)
        {
            return Ok(new TipoEquipamentoFacade().DeletarTipoEquipamento(parametros.IdTipoEquipamento));
        }
    }
}
