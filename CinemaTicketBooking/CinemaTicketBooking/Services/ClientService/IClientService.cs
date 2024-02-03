using CinemaTicketBooking.Models.DTOs;

namespace CinemaTicketBooking.Services.ClientService
{
    public interface IClientService
    {
        Task CreateClient(ClientDTO clientDTO);
        Task<ClientDTO> GetClientById(Guid id); 
        Task<ClientDTO> GetClientByFirstName(string firstname);
        void DeleteClient(Guid id);
        Task<List<ClientDTO>> GetAllClients();
  }
}
