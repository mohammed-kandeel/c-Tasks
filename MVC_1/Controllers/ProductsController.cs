using Microsoft.AspNetCore.Mvc;
using MVC_1.Models;
namespace MVC_1.Controllers;

public class ProductsController : Controller
{
    #region Actions


    //[HttpGet]  by default method get
    // baseurl/products/test
    public string Test()
    {
        return "Hello Product";
    }

    // [Status code , Content type [default text/palin] , Content ]
    // baseurl/products/test2
    [HttpGet]
    public ContentResult Test2()
    {
        var contentResult = new ContentResult();
        contentResult.Content = "Test 2</br>new Line";
        contentResult.ContentType = "Text/html";
        contentResult.StatusCode = StatusCodes.Status200OK;
        return contentResult;

        //helper method
        return Content(content: "Test 2</br>new Line", contentType: "text/html");
    }

    [HttpGet]
    public IActionResult Test3()
    {
        if (true)
            return Content(content: "Test 2</br>new Line", contentType: "text/html");
        else
            return NotFound();
    }

    //master Action
    //baseUrl/products
    //baseUrl/products/index
    ////[HttpGet]
    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = new List<Product>()
        {
            new Product{Id=1,Name="Lap"},
            new Product{Id=2,Name="TV"}
        };
        return Json(products);
    }

    [NonAction]
    public IActionResult Test5()
    {
        return View();
    }


    //products/GetProductById/id
    //[HttpGet]
    public IActionResult GetProductById(int id)
    {
        if (id < 0)
            return BadRequest();
        if (id == 0)
            //return RedirectToAction(nameof(GetProducts));
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
        if (id < 10)
            return NotFound();

        return Json(new Product
        {
            Id = id,
            Name = "Lap"
        });
    }

    //products/RedirectAction
    [HttpGet]
    public IActionResult RedirectAction()
    {
        return Redirect("https://www.youtube.com/");
    }

    [HttpGet]
    public IActionResult DownloadPdf()
    {
        byte[] file = System.IO.File.ReadAllBytes("wwwroot/file/PdfSample.pdf");
        return File(file, "application/pdf", "Test dawnload pdf");
    }
    #endregion


    #region Routing
    //BaseUrl/Controller/Action/Segment
    //Segment --> Static segement  , variable segement , mixed segement
    //BaseUrl/Products/Test/Ten
    //BaseUrl/Products/Test/{Num} 
    //BaseUrl/Products/Test/X{Num}

    //Param --> segement , query param 
    //BaseUrl/Products/Test?num=10

    [HttpGet("Products/Test0001")]
    public IActionResult TestRouting()
    {
        return Json("Test Routing");
    }

    //BaseUrl/Products/TestRouting/10
    //BaseUrl/Products/TestRouting?id=10
    //[HttpGet("TestingRoute/Test{id:int}")]
    [HttpGet("TestingRoute/Test{id:int}")]
    public IActionResult TestRouting(int id)
    {
        return Json($"Hello with id : {id}");
    }



    //BaseUrl/Products/TestRouting
    //BaseUrl/Products/TestRouting/10
    //BaseUrl/Products/TestRouting/10?name=Mariam
    //BaseUrl/Products/TestRouting/?id=10&name=Mariam
    public IActionResult TestRouting(int id, string name)
    {
        return Json($"Hello from TestRouting : id = {id} , name = {name}");
    }

    #endregion


    #region Model binding
    //Action --> Params [Simple data , Complex data [user defined data type] , collection]

    [HttpGet]
    //BaseUrl/Products/GetById
    public IActionResult GetById([FromQuery] int id, [FromQuery(Name = "id2")] int anotherId)
    {
        return Json(new { id = id, anotherId = anotherId });
    }


    //Complex data
    //BaseUrl/Products/Search?Term=?&MinPrice=?&Page=?
    //BaseUrl/Products/Search?filter.Term=?&filter.MinPrice=?&filter.Page=?
    [HttpGet]
    public IActionResult Search(ProductFilter filter)
    {
        return Content("Search completed");
    }


    //Collection
    //BaseUrl/Products/GetByIds
    //BaseUrl/products/GetByIds?ids=10&ids=20&ids=30
    //BaseUrl/products/GetByIds?ids[0]=10&ids[1]=20&ids[2]=30
    [HttpGet]
    public IActionResult GetByIds(int[] ids)
    {
        return Json(new
        {
            ids
        });
    }

    #endregion
}
