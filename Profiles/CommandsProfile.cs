using AutoMapper;
using CommanderApi.Dtos;
using CommanderApi.Models;

namespace CommanderApi.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source => Target
            CreateMap<Command, CommandReadDto>();

            // Target => Source
            CreateMap<CommandCreateDto, Command>();
        }
    }
}