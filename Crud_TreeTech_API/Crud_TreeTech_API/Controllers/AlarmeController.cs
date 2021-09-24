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
    [Route("v1/Alarme")]
    public class AlarmeController : ControllerBase
    {
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListaTodos()
        {
            return Ok(new AlarmeFacade().ListarTodos());
        }

        [HttpGet]
        [Route("ListarUm")]
        public IActionResult ListaUm([FromQuery] int idAlarme)
        {
            return Ok(new AlarmeFacade().ListaUm(idAlarme));
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] Alarmes parametros)
        {
            return Ok(new AlarmeFacade().CadastrarAlarme(parametros.NomeAlarme, parametros.IdClassificacaoAlarme, parametros.IdEquipamento,parametros.DataCadastro,parametros.Status));
        }

        [HttpPost]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] Alarmes parametros)
        {
            return Ok(new AlarmeFacade().AtualizarAlarme(parametros.IdAlarme,parametros.NomeAlarme, parametros.IdClassificacaoAlarme, parametros.IdEquipamento, parametros.Status));
        }

        [HttpPost]
        [Route("Deletar")]
        public IActionResult Deletar([FromBody] Alarmes parametros)
        {
            return Ok(new AlarmeFacade().DeletarAlarme(parametros.IdAlarme));
        }
    }
}
