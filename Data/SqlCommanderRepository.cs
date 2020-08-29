using System;
using System.Collections.Generic;
using System.Linq;
using CommanderApi.Models;

namespace CommanderApi.Data
{
    public class SqlCommanderRepository : ICommanderRepository
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

        public void CreateCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(Command));

            _db.Commands.Add(command);

            SaveChanges();
        }

        public void UpdateCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(Command));

            // All update stuff done by mapper profile
            // To set data from to
            // Only need to save changes in case of the Command is valid

            SaveChanges();
        }

        // HardDelete
        public void DeleteCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(Command));

            _db.Commands.Remove(command);
            
            SaveChanges();
        }

        public bool SaveChanges()
        {
            return _db.SaveChanges() >= 0;
        }
    }
}