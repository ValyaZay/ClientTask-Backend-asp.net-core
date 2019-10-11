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
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet(ApiRoutes.Client.GetAll)]
        public IActionResult Get()
        {
            List<ClientViewModel> clientViewModels = _clientService.GetAllClients();
            return Ok(clientViewModels);
        }

        [HttpGet(ApiRoutes.Client.GetClientById)]
        public IActionResult GetClientById(int id)
        {
            ClientViewModel clientViewModel = _clientService.GetClientById(id);
            return Ok(clientViewModel);
        }
        //test
    }
}
