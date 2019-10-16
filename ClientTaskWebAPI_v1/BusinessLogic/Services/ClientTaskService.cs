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

        public bool Delete(int id)
        {
            ClientTaskDTO clientTaskDTO = clientTaskRepository.GetTasksById(id);
            if(clientTaskDTO == null)
            {
                throw new NullReferenceException("The item with ID=" + id + " does not exist");
            }
            else
            {
                try
                {
                    bool status = clientTaskRepository.Delete(id);
                    return status;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
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

        public bool Update(UpdateTaskViewModel updateTaskViewModel)
        {
            ClientTaskDTO clientTaskDTO = new ClientTaskDTO();
            clientTaskDTO.Id = updateTaskViewModel.Id;
            clientTaskDTO.TaskName = updateTaskViewModel.TaskName;
            clientTaskDTO.Description = updateTaskViewModel.Description;
            clientTaskDTO.ClientAddress = updateTaskViewModel.ClientAddress;
            clientTaskDTO.ClientId = updateTaskViewModel.ClientId;
            clientTaskDTO.StartTime = updateTaskViewModel.StartTime;
            clientTaskDTO.EndTime = updateTaskViewModel.EndTime;

            bool status = clientTaskRepository.Update(clientTaskDTO);
            return status;
        }
    }
}
