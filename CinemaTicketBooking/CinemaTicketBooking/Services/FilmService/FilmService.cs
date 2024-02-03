using CinemaTicketBooking.Repositories;
using AutoMapper;
using CinemaTicketBooking.Models.DTOs;
using FilmTicketBooking.Models;
namespace CinemaTicketBooking.Services.FilmService
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public FilmService(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }   

        public async Task<FilmDTO> GetFilmById(Guid id)
        {
            var film = _filmRepository.GetFilmById(id);
            return _mapper.Map<FilmDTO>(film);
        }

        public async Task<FilmDTO> GetFilmByFilmName(string filmName)
        {
            var film = _filmRepository.GetFilmByFilmName(filmName);
            return _mapper.Map<FilmDTO>(film);
        }

        public async Task CreateFilm(FilmDTO filmDTO)
        {
            var film = _mapper.Map<Film>(filmDTO);
            await _filmRepository.CreateAsync(film);
            await _filmRepository.SaveAsync();
        }

        public async Task <List<FilmDTO>> GetAllFilms()
        {
            var films = await _filmRepository.GetAll();
            return _mapper.Map<List<FilmDTO>>(films);
        }

        public void DeleteFilm(Guid id)
        {
            var film = _filmRepository.GetFilmById(id);
            _filmRepository.Delete(film);
            _filmRepository.Save();
        }
    }
}
