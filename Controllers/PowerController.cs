using Microsoft.AspNetCore.Mvc;

namespace Api_Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PowerController : ControllerBase {

    private readonly ApplicationDbContext _context;

    public PowerController(ApplicationDbContext dbContext) {
        this._context = dbContext;
    }

    // Afficher la Liste de tous les Héros
    [HttpGet]
    public async Task<ActionResult<List<Power>>> GetPower() {
        var myPowersList = await _context.Powers.ToListAsync();
        return Ok(myPowersList);
    }
    
}