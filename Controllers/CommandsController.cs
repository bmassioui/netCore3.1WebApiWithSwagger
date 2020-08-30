using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommanderApi.Data;
using CommanderApi.Dtos;
using CommanderApi.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        /// <summary>
        /// Read all resources
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Read single resource
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetById")]
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
        /// <summary>
        /// Create a new resource
        /// </summary>
        /// <param name="commandCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var command = _mapper.Map<Command>(commandCreateDto);

            _respository.CreateCommand(command);

            // return Ok(command); // 200 OK

            var commandReadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(nameof(GetById), new { Id = commandReadDto.Id }, commandReadDto); // 201 Created
        }

        // Put (Update the entire resource)
        // api/commands/{id}
        /// <summary>
        /// Update an entire resource
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var command = _respository.GetById(id);

            if (command == null)
                return NotFound(); // 404


            _mapper.Map(commandUpdateDto, command);

            _respository.UpdateCommand(command);

            return NoContent(); // 204
        }

        // Patch (Update the partial resource)
        // api/commands/{id}
        // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.jsonpatch.jsonpatchdocument?view=aspnetcore-3.0
        // Expected value [{"op" : "", "path": "", "value" : ""}] operation {copy/remove/move/replace}
        // the possibility to passe more object within the array to update multiple lines
        /*
        [
         {
          "op": "replace",
          "path": "/HowTo",
          "value": "1005 HowTo"
         },
         {
          "op": "replace",
          "path": "/Line",
          "value": "1005 Line"
         }
        ]
      */
      /// <summary>
      /// Update partial resource
      /// </summary>
      /// <param name="id"></param>
      /// <param name="patchDocument"></param>
      /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var command = _respository.GetById(id);

            if (command == null)
                return NotFound(); // 404

            var commandToPatch = _mapper.Map<CommandUpdateDto>(command);

            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
                return ValidationProblem(ModelState); // 400 bad request

            _mapper.Map(commandToPatch, command);
            _respository.UpdateCommand(command);

            return NoContent(); // 204
        }

        // Delete
        // api/commands/{id}
        /// <summary>
        /// Delete a single resource
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _respository.GetById(id);

            if (command == null)
                return NotFound(); // 404

            _respository.DeleteCommand(command);

            return NoContent();
        }
    }
}