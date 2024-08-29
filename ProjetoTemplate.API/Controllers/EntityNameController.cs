using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTemplate.BL;
using ProjetoTemplate.Domain.DTO;
using ProjetoTemplate.Domain.DTO.Authentication;
using ProjetoTemplate.Domain.DTO.EntityName;
using System;
using System.Threading.Tasks;

namespace ProjetoTemplate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class EntityNameController : ControllerBase
    {
        private readonly IEntityNameBO _EntityNameBO;

        public EntityNameController(IEntityNameBO EntityNameBO)
        {
            _EntityNameBO = EntityNameBO;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] EntityNameFilterDTO filter)
        {
            try
            {
                var result = await _EntityNameBO.GetAll(filter);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha na busca dos EntityNames.");
            }
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] Domain.DTO.EntityName.EntityNameDTO EntityName)
        {
            try
            {
                var result = await _EntityNameBO.SaveUpdate(EntityName);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao salvar/atualizar EntityName.");
            }
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] Domain.DTO.EntityName.EntityNameDTO EntityName)
        {
            try
            {
                var result = await _EntityNameBO.SaveUpdate(EntityName);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao salvar/atualizar EntityName.");
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var result = await _EntityNameBO.GetById(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha na busca do EntityName.");
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long Id)
        {
            try
            {
                var result = await _EntityNameBO.Delete(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao deletar EntityName");
            }
        }

        [HttpPatch("ActivateDisable")]
        public async Task<IActionResult> ActivateDisable([FromBody] ActivateDisableDeleteDTO model)
        {
            try
            {
                var result = await _EntityNameBO.ActivateDisable(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao atualizar EntityName. Ex: {ex.Message}");
            }
        }

        [HttpPost("Export2Excel")]
        public async Task<IActionResult> Export2Excel([FromBody] EntityNameFilterDTO filter)
        {
            try
            {
                var result = await _EntityNameBO.Export2Excel(filter);
                return File(result.Memory, result.FileExtension, result.FileName);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao exportar o excel. Ex: {ex.Message}");
            }
        }
    }
}
