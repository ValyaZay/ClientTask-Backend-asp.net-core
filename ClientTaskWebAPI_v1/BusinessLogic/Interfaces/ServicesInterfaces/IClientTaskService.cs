using ClientTaskWebAPI_v1.DTOandViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.BusinessLogic.Interfaces.ServicesInterfaces
{
    public interface IClientTaskService
    {
        List<ClientTaskViewModel> GetTasksByClientId(int id);
        ClientTaskViewModel GetTaskById(int id);

        int Create(CreateTaskViewModel createTaskViewModel);

        bool Update(UpdateTaskViewModel updateTaskViewModel);

        bool Delete(int id);
    }
}
