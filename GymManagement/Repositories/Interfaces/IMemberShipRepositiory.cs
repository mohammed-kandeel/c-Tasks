using GymManagement.Entities;
using System.Linq.Expressions;

namespace GymManagement.Repositories.Interfaces;

public interface IMemberShipRepositiory
{
    Task<bool> AnyAcync(Expression<Func<MemberShip,bool>> predicate, CancellationToken ct);


}
