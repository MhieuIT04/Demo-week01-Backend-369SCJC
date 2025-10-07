using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAPI_DotNet.Application.Features.Menus.Commands.CreateMenu;
using MyAPI_DotNet.Application.Features.Menus.Commands.DeleteMenu;
using MyAPI_DotNet.Application.Features.Menus.Commands.UpdateMenu;
using MyAPI_DotNet.Application.Features.Menus.Queries.GetAllMenus;
using MyAPI_DotNet.Application.Features.Menus.Queries.GetMenuById;
using MyAPI_DotNet.Domain.Entities;

namespace MyAPI_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/menus
        [HttpGet]
        public async Task<IActionResult> GetAllMenus()
        {
            var query = new GetAllMenusQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/menus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            var query = new GetMenuByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        // POST: api/menus
        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] CreateMenuCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMenuById), new { id = result.Id }, result);
        }

        // PUT: api/menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody] UpdateMenuCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var command = new DeleteMenuCommand { Id = id };
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}