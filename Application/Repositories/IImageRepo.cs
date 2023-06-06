using Domain;

namespace Application.Repositories
{
    public interface IImageRepo
    {
        Task AddNewAsync(Image image);
        Task UpdateAsync(Image image);
        Task DeleteAsync(Image image);
        Task<List<Image>> GetAllAsync(); 
        Task<Image> GetByIdAsync(int id);
    }
}
