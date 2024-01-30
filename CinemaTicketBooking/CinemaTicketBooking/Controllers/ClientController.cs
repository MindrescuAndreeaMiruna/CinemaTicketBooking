using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models.DTOs;

//using CinemaTicketBooking.Models.DTOs;
using FilmTicketBooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private  Context _context;

        public ClientController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpGet("clientById/{id}")]
        public async Task<IActionResult> GetClientsById([FromRoute] Guid id)
        {
            var clientById = _context.Clients.FirstOrDefault(x => x.Id == id);
            return Ok(clientById);
        }

        [HttpPost("createClient")]
        public async Task<IActionResult> Create(ClientDTO clientDTO)
        {
            var newClient = new Client();
            newClient.FirstName = clientDTO.FirstName;
            newClient.LastName = clientDTO.LastName;
            newClient.Age = clientDTO.Age;
            newClient.Email = clientDTO.Email;

            await _context.AddAsync(newClient);
            await _context.SaveChangesAsync();

            return Ok(newClient);



        }

    
    }
}

        

/*
public class ClientController : ControllerBase
{
    public static List<Client> clients = new List<Client>
    {
        new Client { Id = 1, FirstName = "Ana", LastName = "Ionescu",  Age = 21, TelephoneNumber = "0745565874", Email = "anaionescu@yahoo.com"},
        new Client { Id = 2, FirstName = "Alex", LastName = "Popescu", Age = 16, TelephoneNumber = "0785410212", Email = "alex98@gmail.com"},
        new Client { Id = 3, FirstName = "Irina", LastName = "Oprisan", Age = 34, TelephoneNumber = "0785469852", Email = "irinao122yahoo.com"},
        new Client { Id = 4, FirstName = "Casiana", LastName = "Perlip", Age = 21, TelephoneNumber = "0754441032" ,Email = "tcasiana76@gmail.com"}

    };

    public static Dictionary<int, Client> clientsDict = new Dictionary<int, Client>
    {
        {1,             new Client { Id = 1, FirstName = "Ana", LastName = "Ionescu",  Age = 21, TelephoneNumber = "0745565874", Email = "anaionescu@yahoo.com"} },
        {2,             new Client { Id = 2, FirstName = "Alex", LastName = "Popescu", Age = 16, TelephoneNumber = "0785410212", Email = "alex98@gmail.com"} }


    }; 

    //Endpoint
    [HttpGet]
    public List<Client> Get()
    {
        return clients;
    }

    [HttpGet("byId")]

    public Client GetById(int id)
    {
        return clients.FirstOrDefault(x => x.Id.Equals(id));
    }

    [HttpGet("byId/{id}")]

    public Client GetByIdInEndpoint(int id)
    {
        return clients.FirstOrDefault(c => c.Id.Equals(id));
    }

    [HttpGet("filter/(name)/(age)")]

    public List<Client> GetWithFilter(string name, int age)
    {
        return clients.Where(s => s.FirstName.Equals(name) && s.Age.Equals(age)).ToList();
    }

    [HttpGet("fromRouteWithId/(id)")]

    public Client GetByIdWithFromRoute([FromRoute] int id)
    {
        Client client = clients.FirstOrDefault(x => x.Id.Equals(id));
        return client;
    }

    [HttpGet("fromHeader")]

    public Client GetbyIdWithFromHeader([FromHeader] int id)
    {
        return clients.FirstOrDefault(x => x.Id.Equals(id));
    }

    [HttpGet("fromQuery")]

    public Client GetByIdWithQuery([FromQuery] int id)
    {
        return clients.FirstOrDefault(x => x.Id.Equals(id));
    }

    //// STATUS CODE 
    [HttpGet("StatusCodeOk")]
    ////200
    public IActionResult StatusCode()
    {

        return Ok("It's ok");
    }

    [HttpGet("NoContent")]
    ////200
    public new IActionResult NoContent()
    {

        return NoContent();
    }

    [HttpGet("StatusCodeNotFound")]
    ////404
    public IActionResult StatusCodeNotFound()
    {
        return NotFound();
    }



    [HttpGet("StatusCodeForbit")]
    //403
    public IActionResult StatusCodeForbit()
    {

        return Forbid();
    }

    [HttpGet("StatusCodeRequest")]
    ////400
    public IActionResult StatusCodeRequest()
    {
        return BadRequest();
    }

    // CREATE 

    [HttpPost("add")]

    public IActionResult Add(Client client)
    {
        clients.Add(client);
        // status code
        // 404 
        return Ok(clients);
    }

    [HttpPost("fromBody")]
    public IActionResult AddWithFromBody([FromBody] Client client)
    {
        clients.Add(client);
        return Ok(clients);
    }

    [HttpPost("addDict")]
    public IActionResult AddInDictionary(Client client)
    {
        clientsDict.Add(client.Id, client);
        return Ok(clientsDict);
    }

    [HttpPost("fromForm")]
    public IActionResult AddWithFromForm([FromForm] Client client)
    {
        clients.Add(client);
        return Ok(clients);
    }

    // update 

    // full update 
    [HttpPost("update")]

    public IActionResult Update([FromBody] Client client)
    {
        var clientIndex = clients.FindIndex((Client x) => x.Id == client.Id);
        clients[clientIndex] = client;

        return Ok(clients);
    }


    // meth async 
    [HttpPost("updateAsync")]
    public async Task<IActionResult> UpdateAsync([FromBody] Client client)
    {
        var clientIndex = clients.FindIndex((Client x) => x.Id == client.Id);

        //await

        clients[clientIndex] = client;

        return Ok(clients);
    }

    //update partial

    [HttpPatch("{id:int}")]
    public IActionResult Patch([FromRoute] int id, [FromBody] JsonPatchDocument<Client> client)
    {
        if (client != null)
        {
            var clientToUpdate = clients.FirstOrDefault(x => x.Id == id);
            client.ApplyTo(clientToUpdate);

            return Ok(clients);
        }
        else
        {
            return BadRequest();
        }
    }

    // delete

    [HttpDelete]

    public IActionResult Delete(Client client)
    {
        var clientIndex = clients.FindIndex((Client x) => x.Id == client.Id);
        clients.RemoveAt(clientIndex);
        return Ok(clients);

    }


}
}

*/