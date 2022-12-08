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
        var myOrganizationList = await _context.Organizations.ToListAsync();
        return Ok(myOrganizationList);
    }

    [HttpPost]
    public async Task<ActionResult<List<Organization>>> CreateOrganization(Organization uneOrganisation) {
        _context.Organizations.Add(uneOrganisation);
        await _context.SaveChangesAsync();
        return Ok("L'organisation " + uneOrganisation.Name + " a bien été créé.");
    }

    // Supprime une Organisation
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Organization>>> DeleteOrganization(int id)
    {
        var organizationToDelete = await _context.Organizations.FindAsync(id);
        _context.Remove(organizationToDelete);
        await _context.SaveChangesAsync();
        return Ok("L'organisation " + organizationToDelete.Name + " a bien été supprimé.");
    }
}