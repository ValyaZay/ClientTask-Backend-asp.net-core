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

        public int Create(ClientTaskViewModel clientTaskViewModel)
        {
            ClientTaskDTO clientTaskDTO = new ClientTaskDTO();
            clientTaskDTO.TaskName = clientTaskViewModel.TaskName;
            clientTaskDTO.Description = clientTaskViewModel.Description;
            clientTaskDTO.ClientAddress = clientTaskViewModel.ClientAddress;
            clientTaskDTO.ClientId = clientTaskViewModel.ClientId;
            clientTaskDTO.StartTime = clientTaskViewModel.StartTime;
            clientTaskDTO.EndTime = clientTaskViewModel.EndTime;

            int id = clientTaskRepository.Create(clientTaskDTO);
            return id;
        }

        public bool Delete(int id)
        {
            ClientTaskGetByIdDTO clientTaskGetByIdDTO = clientTaskRepository.GetTasksById(id);
            if(clientTaskGetByIdDTO == null)
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

        public ClientTaskGetByIdViewModel GetTaskById(int id)
        {
            ClientTaskGetByIdViewModel clientTaskGetByIdViewModel = new ClientTaskGetByIdViewModel();
            
            ClientTaskGetByIdDTO clientTaskGetByIdDTO = clientTaskRepository.GetTasksById(id);

            clientTaskGetByIdViewModel.Id = clientTaskGetByIdDTO.Id;
            clientTaskGetByIdViewModel.TaskName = clientTaskGetByIdDTO.TaskName;
            clientTaskGetByIdViewModel.Description = clientTaskGetByIdDTO.Description;
            clientTaskGetByIdViewModel.ClientAddress = clientTaskGetByIdDTO.ClientAddress;
            clientTaskGetByIdViewModel.StartTime = clientTaskGetByIdDTO.StartTime;
            clientTaskGetByIdViewModel.EndTime = clientTaskGetByIdDTO.EndTime;
            clientTaskGetByIdViewModel.ClientId = clientTaskGetByIdDTO.ClientId;

            return clientTaskGetByIdViewModel;
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

        public bool Update(ClientTaskViewModel clientTaskViewModel)
        {
            ClientTaskDTO clientTaskDTO = new ClientTaskDTO();
            clientTaskDTO.Id = clientTaskViewModel.Id;
            clientTaskDTO.TaskName = clientTaskViewModel.TaskName;
            clientTaskDTO.Description = clientTaskViewModel.Description;
            clientTaskDTO.ClientAddress = clientTaskViewModel.ClientAddress;
            clientTaskDTO.ClientId = clientTaskViewModel.ClientId;
            clientTaskDTO.StartTime = clientTaskViewModel.StartTime;
            clientTaskDTO.EndTime = clientTaskViewModel.EndTime;

            bool status = clientTaskRepository.Update(clientTaskDTO);
            return status;
            
        }
    }
}
