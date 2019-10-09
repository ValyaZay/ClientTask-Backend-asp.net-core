using ClientTaskWebAPI_v1.BusinessLogic.Interfaces.RepositoriesInterfaces;
using ClientTaskWebAPI_v1.BusinessLogic.Interfaces.ServicesInterfaces;
using ClientTaskWebAPI_v1.DTOandViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.BusinessLogic.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<ClientViewModel> GetAllClients()
        {
            List<ClientDTO> clientDTOs = _clientRepository.GetAllClients();

            List<ClientViewModel> clientViewModels = new List<ClientViewModel>();

            foreach (ClientDTO clientDTO in clientDTOs)
            {
                ClientViewModel clientViewModel = new ClientViewModel();
                clientViewModel.Id = clientDTO.Id;
                clientViewModel.FirstName = clientDTO.FirstName;
                clientViewModel.LastName = clientDTO.LastName;
                clientViewModel.Address = clientDTO.Address;

                int[] phoneArray = clientDTO.PhoneNumber;
                string phoneAsString = "";
                foreach (int phone in phoneArray)
                {
                    phoneAsString += phone + "; ";
                }
                char[] trimChars = new char[] { ' ', ';' };
                phoneAsString = phoneAsString.Trim(trimChars);
                clientViewModel.PhoneNumber = phoneAsString;

                clientViewModels.Add(clientViewModel);
            }
            return clientViewModels;
        }
    }
}
