﻿using ClientTaskWebAPI_v1.BusinessLogic.Interfaces.RepositoriesInterfaces;
using ClientTaskWebAPI_v1.Data.Entities;
using ClientTaskWebAPI_v1.DTOandViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.Data.Repositories
{
    public class ClientTaskRepository : IClientTaskRepository
    {
        private List<ClientTask> tasksList;

        public ClientTaskRepository()
        {
            tasksList = new List<ClientTask>()
            {
                new ClientTask() { Id = 1, TaskName = "Task_1", Description = "Do Task_1", ClientAddress = "London", StartTime = new DateTime (2019, 10, 10, 13, 15, 12), EndTime = new DateTime (2019, 10, 10, 13, 24, 36), ClientId = 101},
                new ClientTask() { Id = 2, TaskName = "Task_2", Description = "Do Task_2", ClientAddress = "Kiev", StartTime = new DateTime (2019, 10, 10, 14, 24, 12), EndTime = new DateTime (2019, 10, 10, 14, 36, 36), ClientId = 101},
                new ClientTask() { Id = 3, TaskName = "Task_3", Description = "Do Task_3", ClientAddress = "Paris", StartTime = new DateTime (2019, 10, 10, 14, 24, 12), EndTime = new DateTime (2019, 10, 10, 14, 36, 36), ClientId = 101},
                new ClientTask() { Id = 4, TaskName = "Task_4", Description = "Do Task_4", ClientAddress = "Kiev", StartTime = new DateTime (2019, 10, 10, 14, 24, 12), EndTime = new DateTime (2019, 10, 10, 14, 36, 36), ClientId = 3},
                new ClientTask() { Id = 5, TaskName = "Task_5", Description = "Do Task_5", ClientAddress = "Kabul", StartTime = new DateTime (2019, 10, 10, 14, 24, 12), EndTime = new DateTime (2019, 10, 10, 14, 36, 36), ClientId = 3},
            };
        }

        public int Create(ClientTaskDTO clientTaskDTO)
        {
            ClientTask clientTask = new ClientTask();
            clientTask.TaskName = clientTaskDTO.TaskName;
            clientTask.Description = clientTaskDTO.Description;
            clientTask.ClientAddress = clientTaskDTO.ClientAddress;
            clientTask.ClientId = clientTaskDTO.ClientId;
            clientTask.StartTime = Convert.ToDateTime(clientTaskDTO.StartTime);
            clientTask.EndTime = Convert.ToDateTime(clientTaskDTO.EndTime);
            clientTask.Id = tasksList.Max(t => t.Id) + 1;

            tasksList.Add(clientTask);
            return clientTask.Id;
        }

        public bool Delete(int id)
        {
            ClientTask clientTask = tasksList.FirstOrDefault(t => t.Id == id);
            if(clientTask != null)
            {
                tasksList.Remove(clientTask);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ClientTaskDTO> GetTasksByClientId(int id)
        {
            List<ClientTaskDTO> clientTaskDTOs = new List<ClientTaskDTO>();
            List<ClientTask> chosenTasks = tasksList.Where(task => task.ClientId == id).ToList();

            foreach(ClientTask clientTask in chosenTasks)
            {
                ClientTaskDTO clientTaskDTO = new ClientTaskDTO();
                clientTaskDTO.Id = clientTask.Id;
                clientTaskDTO.TaskName = clientTask.TaskName;
                clientTaskDTO.Description = clientTask.Description;
                clientTaskDTO.ClientAddress = clientTask.ClientAddress;
                clientTaskDTO.StartTime = clientTask.StartTime.ToString();
                clientTaskDTO.EndTime = clientTask.EndTime.ToString();
                clientTaskDTO.ClientId = clientTask.ClientId;

                clientTaskDTOs.Add(clientTaskDTO);

            }
            return clientTaskDTOs;
        }

        public ClientTaskGetByIdDTO GetTasksById(int id)
        {
            ClientTask clientTask = tasksList.Where(task => task.Id == id)
                                             .FirstOrDefault();

            ClientTaskGetByIdDTO clientTaskGetByIdDTO = new ClientTaskGetByIdDTO();
            clientTaskGetByIdDTO.Id = clientTask.Id;
            clientTaskGetByIdDTO.TaskName = clientTask.TaskName;
            clientTaskGetByIdDTO.Description = clientTask.Description;
            clientTaskGetByIdDTO.ClientAddress = clientTask.ClientAddress;
            clientTaskGetByIdDTO.StartTime = clientTask.StartTime;
            clientTaskGetByIdDTO.EndTime = clientTask.EndTime;
            clientTaskGetByIdDTO.ClientId = clientTask.ClientId;

            return clientTaskGetByIdDTO;
        }

        public bool Update(ClientTaskDTO clientTaskDTO)
        {
            ClientTask clientTask = tasksList.FirstOrDefault(t => t.Id == clientTaskDTO.Id);
            if(clientTask != null)
            {
                clientTask.TaskName = clientTaskDTO.TaskName;
                clientTask.Description = clientTaskDTO.Description;
                clientTask.ClientAddress = clientTaskDTO.ClientAddress;
                clientTask.StartTime = Convert.ToDateTime(clientTaskDTO.StartTime);
                clientTask.EndTime = Convert.ToDateTime(clientTaskDTO.EndTime);
                clientTask.ClientId = clientTaskDTO.ClientId;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
