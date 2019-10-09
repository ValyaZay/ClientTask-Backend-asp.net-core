using ClientTaskWebAPI_v1.BusinessLogic.Interfaces.RepositoriesInterfaces;
using ClientTaskWebAPI_v1.Data.Entities;
using ClientTaskWebAPI_v1.DTOandViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private List<Client> clientsList;

        public ClientRepository()
        {
            clientsList = new List<Client>()
            {
                new Client() { Id = 1, FirstName = "John", LastName = "Smith",  Address = "London", PhoneNumber = new int[] { 12345, 45698 }},
                new Client() { Id = 2, FirstName = "Sara", LastName = "Waters",  Address = "Paris", PhoneNumber = new int[] { 5698, 4578, 12358 }},
                new Client() { Id = 3, FirstName = "Bob", LastName = "Petrov",  Address = "Kiev", PhoneNumber = new int[] { 45698, 14587 }},
            };
        }

        public List<ClientDTO> GetAllClients()
        {
            List<ClientDTO> clientsDTO = new List<ClientDTO>();

            foreach (Client client in clientsList)
            {
                ClientDTO clientDTO = new ClientDTO();
                clientDTO.Id = client.Id;
                clientDTO.FirstName = client.FirstName;
                clientDTO.LastName = client.LastName;
                clientDTO.Address = client.Address;
                clientDTO.PhoneNumber = client.PhoneNumber;

                clientsDTO.Add(clientDTO);
            }

            return clientsDTO;
        }
    }
}
