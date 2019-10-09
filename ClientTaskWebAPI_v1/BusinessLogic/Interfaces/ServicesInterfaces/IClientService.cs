using ClientTaskWebAPI_v1.DTOandViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.BusinessLogic.Interfaces.ServicesInterfaces
{
    public interface IClientService
    {
        List<ClientViewModel> GetAllClients();
    }
}
