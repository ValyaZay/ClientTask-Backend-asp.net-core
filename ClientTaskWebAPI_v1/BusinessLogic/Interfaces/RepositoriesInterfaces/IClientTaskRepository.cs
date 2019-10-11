using ClientTaskWebAPI_v1.DTOandViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.BusinessLogic.Interfaces.RepositoriesInterfaces
{
    public interface IClientTaskRepository
    {
        List<ClientTaskDTO> GetTasksByClientId(int id);
    }
}
