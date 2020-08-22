using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommanderApi.Data;
using CommanderApi.Dtos;
using CommanderApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommanderApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")] //api/commands
    public class CommandsController : ControllerBase
    {
        public readonly ICommanderRepository _respository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepository respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }

        // api/commands
        [HttpGet] // Action verb
        public ActionResult<IEnumerable<CommandReadDto>> GetAll()
        {
            var commands = _respository
                                      .GetAll();
            if (!commands.Any())
                return NotFound();

            var result = _mapper.Map<IEnumerable<CommandReadDto>>(commands);

            return Ok(result);
        }

        // api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetById(int id)
        {
            var command = _respository
                                      .GetById(id);

            if (command == null)
                return NotFound();

            var result = _mapper.Map<CommandReadDto>(command);

            return Ok(result);
        }

        // api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var command = _mapper.Map<Command>(commandCreateDto);

            _respository.CreateCommand(command);

            return Ok(command);
        }

        // Put

        // Delete
    }
}