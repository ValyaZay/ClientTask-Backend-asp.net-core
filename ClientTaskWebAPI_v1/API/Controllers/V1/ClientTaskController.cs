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
            try
            {
                ClientTaskGetByIdViewModel clientTaskGetByIdViewModel = clientTaskService.GetTaskById(taskId);
                return Ok(clientTaskGetByIdViewModel);
            }
            catch (Exception)
            {
                return NotFound("Task with id= " + taskId + " does not exist");
            }
            
        }

        [HttpPost(ApiRoutes.ClientTask.Create)]
        public IActionResult Create([FromBody] ClientTaskViewModel clientTaskViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id = clientTaskService.Create(clientTaskViewModel);
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                    var locationUri = baseUrl + "/" + ApiRoutes.ClientTask.GetTaskById.Replace("{taskId}", id.ToString()).Replace("{clientId}", clientTaskViewModel.ClientId.ToString());
                    return Created(locationUri, new ClientTaskViewModel { Id = id, 
                                                                          TaskName = clientTaskViewModel.TaskName,
                                                                          Description = clientTaskViewModel.Description,
                                                                          ClientAddress = clientTaskViewModel.ClientAddress,
                                                                          ClientId = clientTaskViewModel.ClientId,
                                                                          StartTime = clientTaskViewModel.StartTime,
                                                                          EndTime = clientTaskViewModel.EndTime 
                                                                        });
                    
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return BadRequest("Insert valid data");
        }

        [HttpPut(ApiRoutes.ClientTask.Update)]
        public IActionResult Update([FromBody] ClientTaskViewModel clientTaskViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var status = clientTaskService.Update(clientTaskViewModel);
                    if (!status)
                    {
                        return BadRequest("Task is not updated");
                    }
                    else
                    {
                        return NoContent();
                    }

                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return BadRequest("Insert valid data");
        }

        [HttpDelete(ApiRoutes.ClientTask.Delete)]
        public IActionResult Delete(int taskId)
        {
            try
            {
                var status = clientTaskService.Delete(taskId);
                if (status)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Task is not deleted");
                }

            }
            catch (Exception)
            {
                return NotFound("The item with ID=" + taskId + " does not exist");
            }
        }
    }
}
