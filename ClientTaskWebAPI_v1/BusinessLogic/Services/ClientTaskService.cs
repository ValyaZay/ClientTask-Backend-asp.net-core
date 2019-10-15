using ClientTaskWebAPI_v1.BusinessLogic.Interfaces.RepositoriesInterfaces;
using ClientTaskWebAPI_v1.BusinessLogic.Interfaces.ServicesInterfaces;
using ClientTaskWebAPI_v1.DTOandViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.BusinessLogic.Services
{
    public class ClientTaskService : IClientTaskService
    {
        private readonly IClientTaskRepository clientTaskRepository;

        public ClientTaskService(IClientTaskRepository clientTaskRepository)
        {
            this.clientTaskRepository = clientTaskRepository;
        }

        public int Create(CreateTaskViewModel createTaskViewModel)
        {
            ClientTaskDTO clientTaskDTO = new ClientTaskDTO();
            clientTaskDTO.TaskName = createTaskViewModel.TaskName;
            clientTaskDTO.Description = createTaskViewModel.Description;
            clientTaskDTO.ClientAddress = createTaskViewModel.ClientAddress;
            clientTaskDTO.ClientId = createTaskViewModel.ClientId;
            clientTaskDTO.StartTime = createTaskViewModel.StartTime;
            clientTaskDTO.EndTime = createTaskViewModel.EndTime;

            int id = clientTaskRepository.Create(clientTaskDTO);
            return id;
        }

        public ClientTaskViewModel GetTaskById(int id)
        {
            ClientTaskViewModel clientTaskViewModel = new ClientTaskViewModel();
            ClientTaskDTO clientTaskDTO = clientTaskRepository.GetTasksById(id);
            clientTaskViewModel.Id = clientTaskDTO.Id;
            clientTaskViewModel.TaskName = clientTaskDTO.TaskName;
            clientTaskViewModel.Description = clientTaskDTO.Description;
            clientTaskViewModel.ClientAddress = clientTaskDTO.ClientAddress;
            clientTaskViewModel.StartTime = clientTaskDTO.StartTime;
            clientTaskViewModel.EndTime = clientTaskDTO.EndTime;
            clientTaskViewModel.ClientId = clientTaskDTO.ClientId;

            return clientTaskViewModel;
        }

        public List<ClientTaskViewModel> GetTasksByClientId(int id)
        {
            List<ClientTaskDTO> clientTaskDTOs = clientTaskRepository.GetTasksByClientId(id);

            List<ClientTaskViewModel> clientTaskViewModels = new List<ClientTaskViewModel>();
            foreach(ClientTaskDTO clientTaskDTO in clientTaskDTOs)
            {
                ClientTaskViewModel clientTaskViewModel = new ClientTaskViewModel();
                clientTaskViewModel.Id = clientTaskDTO.Id;
                clientTaskViewModel.TaskName = clientTaskDTO.TaskName;
                clientTaskViewModel.Description = clientTaskDTO.Description;
                clientTaskViewModel.ClientAddress = clientTaskDTO.ClientAddress;
                clientTaskViewModel.StartTime = clientTaskDTO.StartTime;
                clientTaskViewModel.EndTime = clientTaskDTO.EndTime;
                clientTaskViewModel.ClientId = clientTaskDTO.ClientId;

                clientTaskViewModels.Add(clientTaskViewModel);
            }
            return clientTaskViewModels;

        }
    }
}
