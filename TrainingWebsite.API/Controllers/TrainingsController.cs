using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingWebsite.Application.Features.Training.Commands.CreateTraining;
using TrainingWebsite.Application.Features.Training.Queries.GetAllTrainings;
using TrainingWebsite.Application.Features.Training.Queries.GetTrainingDetails;

namespace TrainingWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET: api/<TrainingsController>
        [HttpGet]
        public async Task<List<TrainingDto>> Get()
        {
            var allTrainings = await _mediator.Send(new GetAllTrainingsQuery());
            return allTrainings;
        }

        // GET api/<TrainingsController>/5
        [HttpGet("{id}")]
        public async Task<TrainingDetailsDto> Get(Guid id)
        {
            return await _mediator.Send(new GetTrainingDetailsQuery(id));
        }

        // POST api/<TrainingsController>
        [HttpPost]
        [Authorize (Roles = "Administrator")] // Only administrators can create a training
        public async Task<Guid> Post([FromBody] CreateTrainingCommand createTrainingCommand)
        {
            return await _mediator.Send(createTrainingCommand);
        }

        // PUT api/<TrainingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TrainingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
