﻿using Curso.Common.DTO;
using Curso.Data.Services;
using Curso.Data.Services.FolderAltaPersona;
using Curso.Model.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Curso.Data.Api.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	[EnableCors("_CURSO_")]
	public class TablesController : ControllerBase
    {
		private readonly ILogger<TablesController> _logger;
		private readonly ICargaTabla _cargaTabla;
		private readonly IAltaPersona _altaPersona;

		public TablesController(ILogger<TablesController> logger, ICargaTabla cargaTabla, IAltaPersona altaPersona)//, ILoginServiceAsync loginService)
		{
			_logger = logger;
			//_loginService = loginService;
			_logger.LogInformation("Constructor TablesController");
			this._cargaTabla = cargaTabla;
			this._altaPersona = altaPersona;
		}

		[HttpGet("Grilla1")]
		public async Task<ActionResult> GetGrilla1()
		{
			var retorno = await _cargaTabla.CargarMiTabla();			
			return Ok(retorno);
		}

		[HttpPost("CrearPersona")]
		public async Task<ActionResult> AltaPersona([FromBody] PersonaTablaDTO persona)
		{
			if(persona.NombreAlta.Length<3 || persona.ApellidoAlta.Length<3)
			{
				return BadRequest(new ResultJson() { Message = "No ingreso nombre o apellido" });
			}
			await _altaPersona.CargarPersona(persona);
			return Ok(new ResultJson() { Message = "Alta realizada con exito"});

		}
	}
}