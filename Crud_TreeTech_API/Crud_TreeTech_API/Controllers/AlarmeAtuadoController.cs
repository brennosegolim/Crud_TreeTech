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
    [Route("v1/AlarmeAtuado")]
    public class AlarmeAtuadoController : ControllerBase
    {
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListaTodos()
        {
            return Ok(new AlarmeAtuadoFacade().ListarTodos());
        }

        [HttpGet]
        [Route("ListarUm")]
        public IActionResult ListaUm([FromQuery] int idAlarmeAtuado)
        {
            return Ok(new AlarmeAtuadoFacade().ListaUm(idAlarmeAtuado));
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] AlarmesAtuados parametros)
        {
            return Ok(new AlarmeAtuadoFacade().CadastrarAlarmeAtuado(parametros.DataEntrada, parametros.IdAlarme));
        }

        [HttpPost]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] AlarmesAtuados parametros)
        {
            return Ok(new AlarmeAtuadoFacade().AtualizarAlarmeAtuado(parametros.DataSaida, parametros.IdAlarme));
        }

        [HttpPost]
        [Route("Deletar")]
        public IActionResult Deletar([FromBody] AlarmesAtuados parametros)
        {
            return Ok(new AlarmeAtuadoFacade().DeletarAlarmeAtuado(parametros.IdAlarmeAtuado));
        }

        [HttpGet]
        [Route("RankingAlarmes")]
        public IActionResult RankingAlarmes()
        {
            return Ok(new AlarmeAtuadoFacade().RankingAlarmes());
        }
    }
}
