using Microsoft.AspNetCore.Mvc;

namespace Api_Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PowerController : ControllerBase {

    private readonly ApplicationDbContext _context;

    public PowerController(ApplicationDbContext dbContext) {
        this._context = dbContext;
    }

    // Affichage de tous les pouvoirs
    [HttpGet]
    public async Task<ActionResult<List<Power>>> GetAllPowers() {
        var myPowersList = await _context.Powers.ToListAsync();
        return Ok(myPowersList);
    }

    [HttpPost]
    public async Task<ActionResult<List<Hero>>> CreatePower(Power unPouvoir) {
        _context.Powers.Add(unPouvoir);
        await _context.SaveChangesAsync();
        return Ok("Le pouvoir " + unPouvoir.Name + " a bien été créé.");
    }

    // Supprime un Pouvoir
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Power>>> DeletePower(int id)
    {
        var powerToDelete = await _context.Powers.FindAsync(id);
        _context.Remove(powerToDelete);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
}