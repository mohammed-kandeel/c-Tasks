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
            Description = "fvd'c;',lokjipho",
            DurationDays = 152,
            Price = 51,
            IsActive = true
        };
        plans.Add(plan);

        plan = new Plan()
        {
            Id = 2,
            Name = "fvdcdesxve  cds vfd cscsx",
            Description = "fvd'c;',lokjvrcexvrecxiph  vdcsljonlm,/ uojklm ,ounklm ",
            DurationDays = 350,
            Price = 510,
            IsActive = false
        };
        plans.Add(plan);
        return View(plans);
    }
}
