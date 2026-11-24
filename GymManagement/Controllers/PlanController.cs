using GymManagement.Context;
using GymManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace GymManagement.Controllers;

public class PlanController : Controller
{
    public GymManagementDbContext DbContext = new GymManagementDbContext();
    public IActionResult IndexTest()
    {
        return View();
    }
    public async Task<IActionResult> Index()
    {
        //var plans = await DbContext.Plans.ToListAsync();
        var plans = new List<Plan>();
        var plan = new Plan()
        {
            Id = 1,
            Name = "fvdcsx",
            Description = "fvd'c;',lokjiphouyguhijkl;.pjiko'lp;.",
            DurationDays = 152,
            Price = 51,
            IsActive = true
        };
        plans.Add(plan);

        plan = new Plan()
        {
            Id = 2,
            Name = "fvdcdesxvecdsvfdcscsx",
            Description = "fvd'c;',lokjvrcexvrecxiphouyguhijkl;.pjiko'lp;.",
            DurationDays = 350,
            Price = 510,
            IsActive = false
        };
        plans.Add(plan);
        return View(plans);
    }
}
