using CinemaTicketBooking.Models.Base;

namespace CinemaTicketBooking.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        //operatii CRUD 

        //Get all data

        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAllAsQueryable();

        //IQueryable nu tine minte informatiile
        //IEnumerable executa query pe server, dar incarca si datele in memorie 
        //List doar tine datele


        //CREATE
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        //UPDATE 

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //DELETE
        
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //FIND

        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);

        //SAVE

        bool Save();
        Task<bool> SaveAsync();

    }

}
