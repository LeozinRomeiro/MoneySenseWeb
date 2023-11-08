using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneySense.ViewModels;
using MoneySense.Data;
using MoneySense.Models.Income;

namespace MoneySense.Controllers
{
    [Route("IncomeUnexpected")]
    [ApiController]
    public class IncomeUnexpectedController : ControllerBase
    {
        [HttpGet] 
        public async Task<ActionResult> GetAsync([FromServices]DataContext data) 
        {
            try
            {
                var unexpecteds = await data.IncomeUnexpecteds.ToListAsync();
                return Ok(unexpecteds);
            }
            catch(Exception)
            {
                return StatusCode(500, "MSCIUG01 - Falha interna!");
            }
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetByIDAsync(
            [FromRoute] int id,
            [FromServices] DataContext data)
        {
            try
            {
                var unexpected = await data.IncomeUnexpecteds.FirstOrDefaultAsync(x => x.Id == id);

                if (unexpected == null)
                    return NotFound();
                
                return Ok(unexpected);
            }
            catch (Exception)
            {
                return StatusCode(500, "MSCIUGBI01 - Falha interna!");
            }
        }
        [HttpPost("")]
        public async Task<ActionResult> PostAsync(
            [FromBody] EditorIncomeUnexpectedViewModel model,
            [FromServices] DataContext data)
        {
            try
            {
                var unexpected = new Unexpected (model.Title, model.Description, model.Value);

                await data.AddAsync(unexpected);
                await data.SaveChangesAsync();

                return Created($"{unexpected.Id}", unexpected);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "MSCIUGBI01 - Não foi possivel incluir registro!");
            }
            catch (Exception)
            {
                return StatusCode(500, "MSCIUGBI02 - Falha interna!");
            }
        }
    }
}
