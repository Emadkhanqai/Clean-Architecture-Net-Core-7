using Application.Repositories;
using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ImageRepo: IImageRepo
    {
        private readonly ApplicationDbContext _context;

        public ImageRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNewAsync(Image image)
        {
           await _context.Images.AddAsync(image);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Image image)
        {
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Image>> GetAllAsync()
        {
            // Applied Eager Loading here because Image has relation with Property
            return await _context.Images.Include(i => i.Property).ToListAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            // Applied Eager Loading here because Image has relation with Property
            return await _context.Images.Include(i => i.Property).Where(x=> x.Id == id).FirstOrDefaultAsync();
        }
    }
}
