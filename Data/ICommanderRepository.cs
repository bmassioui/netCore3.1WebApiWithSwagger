using System.Collections.Generic;
using CommanderApi.Models;

namespace CommanderApi.Data
{
    public interface ICommanderRepository
    {
        /// <summary>
        /// Get list of commands
        /// </summary>
        /// <returns></returns>
        IEnumerable<Command> GetAll();
        /// <summary>
        /// Get command by Id
        /// </summary>
        /// <param name="id">CommandId</param>
        /// <returns></returns>
        Command GetById(int id);
        /// <summary>
        /// Create a new Command
        /// </summary>
        /// <param name="command"></param>
        void CreateCommand(Command command);
        /// <summary>
        /// Update existing Command
        /// </summary>
        /// <param name="command"></param>
        void UpdateCommand(Command command);
        /// <summary>
        /// Delete existing Command
        /// </summary>
        /// <param name="command"></param>
        void DeleteCommand(Command command);
        /// <summary>
        /// Save changes applied on an entity model
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}