using CinemaTicketBooking.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;
using CinemaTicketBooking.Models.DTOs;
using FilmTicketBooking.Models;

namespace CinemaTicketBooking.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientsRepository clientsRepository, IMapper mapper)
        {
            _clientsRepository = clientsRepository;
            _mapper = mapper;
        }

        public async Task<ClientDTO> GetClientById(Guid id)
        {
            var client = _clientsRepository.GetClientById(id);
            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<ClientDTO> GetClientByFirstName(string firstname)
        {
            var client = _clientsRepository.GetClientByFirstName(firstname);
            return _mapper.Map<ClientDTO>(client);
        }

        public async Task CreateClient (ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            await _clientsRepository.CreateAsync(client);
            await _clientsRepository.SaveAsync();
        }

        public async Task <List<ClientDTO>> GetAllClients()
        {
            var clients = await _clientsRepository.GetAll();
            return _mapper.Map<List<ClientDTO>>(clients);
        }

        public void DeleteClient(Guid id)
        {
            var client = _clientsRepository.GetClientById(id);
            _clientsRepository.Delete(client);
            _clientsRepository.Save();
        }

    
    }
}
