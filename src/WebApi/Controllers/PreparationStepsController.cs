using Microsoft.AspNetCore.Mvc;
using Stockpot.BusinessLogic.PreparationSteps;
using System.Threading.Tasks;

namespace Stockpot.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PreparationStepsController : ControllerBase
    {
        private readonly PreparationStepsService _preparationStepsService;

        public PreparationStepsController(
            PreparationStepsService preparationStepsService)
        {
            _preparationStepsService = preparationStepsService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePreparationStepDto dto)
        {
            await _preparationStepsService.Add(dto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdatePreparationStepDto dto)
        {
            var changes = await _preparationStepsService.Update(id, dto);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var changes = await _preparationStepsService.Delete(id);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("switchorder")]
        public async Task<IActionResult> SwitchOrder(int fromId, int toId)
        {
            var changes = await _preparationStepsService.SwitchOrder(fromId, toId);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
