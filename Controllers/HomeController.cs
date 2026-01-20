using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newProject.Models;

namespace newProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext dbContext;

    public HomeController(ILogger<HomeController> logger, AppDbContext _dbContext)
    {
        _logger = logger;
        this.dbContext = _dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("emp")]
    public async Task<IActionResult> Employees()
    {
        List<Emp_Master> emps = await this.dbContext.Emp_Masters.ToListAsync();
        EmployeeViewModel empVM = new EmployeeViewModel
        {
          AllEmaps =   emps
        };
        return View(empVM);
    }

    [HttpPost]
    [Route("empsalary")]
    public async Task<IActionResult> EmployeeSalary([FromBody] int EmpId)
    {
        Salary_Master? salary = await this.dbContext.Salary_Masters.FirstOrDefaultAsync(s => s.Emp_ID == EmpId);
        return Ok(new
        {
            Amount = salary?.Amount,
            DisburshedDate = salary?.DisburshedDate.ToString("F")
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
