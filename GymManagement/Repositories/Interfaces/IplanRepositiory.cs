using GymManagement.Entities;
namespace GymManagement.Repositories.Interfaces;

public interface IplanRepositiory
{
    Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default);
    Task<Plan?> GetPlanByIdAsync(int id, CancellationToken ct = default);
}
