using System.Collections.Generic;
using CommanderApi.Models;

namespace CommanderApi.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public IEnumerable<Command> GetAll()
        {
            var commands = new List<Command> {
                new Command{ Id = 1, HowTo = "Boil an egg",Line = "Boil water",Platform = "Kettle & pan"},
                new Command{ Id = 2, HowTo = "Cut a bread",Line = "Get a knife",Platform = "knife & chopping board"},
                new Command{ Id = 3, HowTo = "Make cup of tea",Line = "Place teabag in cup",Platform = "Kettle & cup"}
            };

            return commands;
        }

        public Command GetById(int id)
        {
            return new Command
            {
                Id = 1,
                HowTo = "Boil an egg",
                Line = "Boil water",
                Platform = "Kettle & pan"
            };
        }

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}