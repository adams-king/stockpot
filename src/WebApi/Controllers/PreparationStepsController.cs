using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stockpot.BusinessLogic.PreparationSteps;
using System.Threading.Tasks;

namespace Stockpot.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PreparationStepsController : ControllerBase
    {
        private readonly PreparationStepsService _preparationStepsService;
        private readonly ILogger<PreparationStepsController> _logger;

        public PreparationStepsController(
            PreparationStepsService preparationStepsService,
            ILogger<PreparationStepsController> logger)
        {
            _preparationStepsService = preparationStepsService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PreparationStepDto preparationStepDto)
        {
            await _preparationStepsService.Add(preparationStepDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PreparationStepDto preparationStepDto)
        {
            var changes = await _preparationStepsService.Update(id, preparationStepDto);

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
