using System.Collections.Generic;
using System.Linq;
using CommanderApi.Models;

namespace CommanderApi.Data
{
    public class SqlCommanderRepository : ICommanderRespository
    {
        private readonly CommanderContext _db;

        public SqlCommanderRepository(CommanderContext db)
        {
            _db = db;
        }

        public IEnumerable<Command> GetAll()
        {
            return _db.Commands
                      .ToList();
        }

        public Command GetById(int id)
        {
            return _db.Commands
                      .SingleOrDefault(command => command.Id == id);
        }
    }
}