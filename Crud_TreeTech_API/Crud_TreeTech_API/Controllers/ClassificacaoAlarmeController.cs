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
    [Route("v1/ClassificacaoAlarme")]
    public class ClassificacaoAlarmeController : ControllerBase
    {
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListaTodos()
        {
            return Ok(new ClassificacaoAlarmeFacade().ListarTodos());
        }

        [HttpGet]
        [Route("ListarUm")]
        public IActionResult ListaUm([FromQuery] int idClassificacaoAlarme)
        {
            return Ok(new ClassificacaoAlarmeFacade().ListaUm(idClassificacaoAlarme));
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] ClassificacaoAlarmes parametros)
        {
            return Ok(new ClassificacaoAlarmeFacade().CadastrarClassificaoAlarme(parametros.NomeClassificacaoAlarme, parametros.EnviarEmail, parametros.Observacao));
        }

        [HttpPost]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] ClassificacaoAlarmes parametros)
        {
            return Ok(new ClassificacaoAlarmeFacade().AtualizarClassificacaoAlarme(parametros.IdClassificacaoAlarme,parametros.NomeClassificacaoAlarme, parametros.EnviarEmail, parametros.Observacao));
        }

        [HttpPost]
        [Route("Deletar")]
        public IActionResult Deletar([FromBody] ClassificacaoAlarmes parametros)
        {
            return Ok(new ClassificacaoAlarmeFacade().DeletarClassificacaoAlarme(parametros.IdClassificacaoAlarme));
        }
    }
}
