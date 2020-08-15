using AutoMapper;
using CommanderApi.Dtos;
using CommanderApi.Models;

namespace CommanderApi.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
        }
    }
}