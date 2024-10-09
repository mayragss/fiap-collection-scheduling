using CollectionSchedulingAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;
using Presentation.Interface;
using Presentation.Model;
using Presentation.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollectionScheduleController : ControllerBase
    {
        private readonly ICollectionScheduleService _service;

        public CollectionScheduleController(ICollectionScheduleService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CollectionScheduleViewModel model)
        {
            try
            {
                var response = await _service.Register
                    (new(
                        model.Cep,
                        model.Street,
                        model.State,
                        model.City,
                        model.Number ?? 0,
                        model.Complement,
                        model.CollectionDate,
                        model.UserId,
                        model.WasteType,
                        model.CollectionScheduleStatus,
                        model.Notes,
                        model.IsRecurring,
                        model.RecurringInterval,
                        model.ConfirmationDate,
                        model.CollectionWindowStart,
                        model.CollectionWindowEnd
                    ));
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao registrar a coleta: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await _service.GetById(id);
                if (!response.Success)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao obter a coleta: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _service.GetAll();
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao obter as coletas: {ex.Message}");
            }
        }
/*

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CollectionScheduleDto model)
        {
            try
            {
                var response = await _service.Update(id, model);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao atualizar a coleta: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _service.Delete(id);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao deletar a coleta: {ex.Message}");
            }
        }*/
    }
}
