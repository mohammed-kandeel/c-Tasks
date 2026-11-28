using GymManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace GymManagement.Controllers;

public class PlanController : Controller
{
    //public GymManagementDbContext DbContext = new GymManagementDbContext();
    //private readonly IplanRepositiory _planRepositiory = new planRepositiory();//DI
    private readonly IplanRepositiory _planRepositiory;
    private readonly IMemberShipRepositiory _memberShipRepositiory;

    public PlanController(IplanRepositiory planRepositiory, IMemberShipRepositiory memberShipRepositiory)
    {
        _planRepositiory = planRepositiory;
        _memberShipRepositiory = memberShipRepositiory;
    }

    #region Index & IndexTest
    public IActionResult IndexTest()
    {
        return View(); //return view with same action name [Views/Plan/IndexTest. cshtml]
        //return View("ViewTEST");
        //return View(new Member() {});
        //return View("ViewTEST", new Member() { });
    }
    //public async Task<IActionResult> Index()
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        //var plans = await DbContext.Plans.ToListAsync();
        //return View(plans);

        var plans = await _planRepositiory.GetAllAsync(ct);
        return View(plans);
    }
    #endregion

    #region Edit [GET & POST]

    #region ViewData vs ViewBag vs TempData
    /*
    ViewData , ViewBag
    -- > Send extra data between controller and view
    -- > Both use the same storage
    -- > Both are avialable in the current HTTP request

    -- > Pass Controller -- > View
    -- > Pass View -- > Layout
    -- > Pass View -- > Partial view

    -- > ViewData -- > object -- > explicit casting
    -- > ViewBag -- > Dynamic -- > no explicit casting


    - TempData
    -- > Send extra data between different HTTP Req
    -- > Survive against the redirect

    TempData["Message"] = "Plan edited successfully";
    return RedirectToAction("Index");

    view : @TempData["Message"]

    TempData.Peek("Key) : Read without marking for delete
    TempData. Keep("Key"): Keep data for another request

    */
    #endregion
    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        if (id <= 0)
            return RedirectToAction(nameof(Index));

        // get plan 
        var plan = await _planRepositiory.GetPlanByIdAsync(id, ct);

        // check if plan is null or is not active  --> redirect to index 
        if (plan is null || !plan.IsActive)
            return RedirectToAction(nameof(Index));

        // check if plan have any memberships
        if (await _memberShipRepositiory.AnyAcync((m => m.Id == id && m.EndDate > DateTime.Now), ct))
            return RedirectToAction(nameof(Index));

        return View(plan);
    }
    #endregion
}