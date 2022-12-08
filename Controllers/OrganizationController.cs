using Microsoft.AspNetCore.Mvc;

namespace Api_Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class OrganizationController : ControllerBase {
    private readonly ApplicationDbContext _context;

    public OrganizationController(ApplicationDbContext dbContext) {
        this._context = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Organization>>> GetAllOrganization() {
        var myOrganizationList = await _context.Heroes.ToListAsync();
        return Ok(myOrganizationList);
    }
}