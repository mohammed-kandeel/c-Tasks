using GymManagement.Context;
using GymManagement.Entities;
using GymManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace GymManagement.Repositories.Classes;

public class MemberShipRepositiory /*(GymDbContext _dbContext)  */ : IMemberShipRepositiory
{
    private readonly GymDbContext _dbContext;

    public MemberShipRepositiory(GymDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> AnyAcync(Expression<Func<MemberShip, bool>> predicate, CancellationToken ct)
    {
        return await _dbContext.MemberShips.AnyAsync(predicate, ct);
    }
}
