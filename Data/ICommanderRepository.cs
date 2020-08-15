using System.Collections.Generic;
using CommanderApi.Models;

namespace CommanderApi.Data
{
    public interface ICommanderRespository
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
        void CreateCommand(Command command);
        /// <summary>
        /// Save changes applied on an entity model
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}