using GymManagement.Context;
using GymManagement.Entities;
using GymManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace GymManagement.Repositories.Classes;

public class planRepositiory : IplanRepositiory
{
    //private readonly GymDbContext _dbContext = new GymDbContext();
    private readonly GymDbContext _dbContext;
    public planRepositiory(GymDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default)
    {
         return await _dbContext.Plans.AsNoTracking().ToListAsync(ct);
    }
    public async Task<Plan?> GetPlanByIdAsync(int id, CancellationToken ct = default)
    {
        return await _dbContext.Plans.FindAsync([id], cancellationToken: ct);
    }
}