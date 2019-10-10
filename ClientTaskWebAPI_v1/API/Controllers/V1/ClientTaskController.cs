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
            if(clientTaskViewModels.Count == 0)
            {
                return NotFound("The client with Id = " + id + " does not have any task");
            }
            return Ok(clientTaskViewModels);
        }
    }
}
