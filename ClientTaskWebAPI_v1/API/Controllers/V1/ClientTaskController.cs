using ClientTaskWebAPI_v1.API.Contracts.V1;
using ClientTaskWebAPI_v1.BusinessLogic.Interfaces.ServicesInterfaces;
using ClientTaskWebAPI_v1.DTOandViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.API.Controllers.V1
{
    [Produces("application/json")]
    public class ClientTaskController : Controller
    {
        private readonly IClientTaskService clientTaskService;

        public ClientTaskController(IClientTaskService clientTaskService)
        {
            this.clientTaskService = clientTaskService;
        }

        [HttpGet(ApiRoutes.ClientTask.GetAllByClientId)]
        public IActionResult GetAllByClientId(int id)
        {
            List<ClientTaskViewModel> clientTaskViewModels = clientTaskService.GetTasksByClientId(id);
            
            return Ok(clientTaskViewModels);
        }

        [HttpGet(ApiRoutes.ClientTask.GetTaskById)]
        public IActionResult GetTaskById(int taskId)
        {
            ClientTaskViewModel clientTaskViewModel = clientTaskService.GetTaskById(taskId);

            return Ok(clientTaskViewModel);
        }

        [HttpPost(ApiRoutes.ClientTask.Create)]
        public IActionResult Create([FromBody] CreateTaskViewModel createTaskViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id = clientTaskService.Create(createTaskViewModel);
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                    var locationUri = baseUrl + "/" + ApiRoutes.ClientTask.GetTaskById.Replace("{taskId}", id.ToString()).Replace("{clientId}", createTaskViewModel.ClientId.ToString());
                    return Created(locationUri, new ClientTaskViewModel { Id = id, 
                                                                          TaskName = createTaskViewModel.TaskName,
                                                                          Description = createTaskViewModel.Description,
                                                                          ClientAddress = createTaskViewModel.ClientAddress,
                                                                          ClientId = createTaskViewModel.ClientId,
                                                                          StartTime = createTaskViewModel.StartTime,
                                                                          EndTime = createTaskViewModel.EndTime 
                                                                        });
                    
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return BadRequest("Insert valid data");
        }
    }
}
