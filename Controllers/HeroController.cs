using Microsoft.AspNetCore.Mvc;

namespace Api_Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class HeroController : ControllerBase {

    // private static List<Hero> heroes = new List<Hero> {
    //     new Hero { Id = 1, Name = "Iron Man", FirstName="Tony", LastName = "Stark", Place="Somewhere" },
    //     new Hero { Id = 2, Name = "Spider Man", FirstName="Peter", LastName = "Parker", Place="Somewhere" },
    // };

    private readonly ApplicationDbContext _context;

    public HeroController(ApplicationDbContext dbContext) {
        this._context = dbContext;
    }

    // Afficher la Liste de tous les Héros
    [HttpGet]
    public async Task<ActionResult<List<Hero>>> GetAllHeroes() {
        var myHeroesList = await _context.Heroes.ToListAsync();
        return Ok(myHeroesList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Hero>>> GetHeroById(int id) {
        var myHero = await _context.Heroes.FindAsync(id);
        return Ok(myHero);
    }

    // Créer un Nouveau Hero
    [HttpPost]
    public async Task<ActionResult<List<Hero>>> CreateHero(Hero unHero) {
        _context.Heroes.Add(unHero);
        await _context.SaveChangesAsync();
        return Ok("Le Héro " + unHero.Name + " a bien été créé.");
    }

    // Mettre à Jour le Héro
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Hero>>> UpdateHero(int id, Hero unHero) {
       var heroToUpdate = await _context.Heroes.FindAsync(id);
       heroToUpdate.Name = unHero.Name;
       heroToUpdate.FirstName = unHero.FirstName;
       heroToUpdate.LastName = unHero.LastName;
       heroToUpdate.Place = unHero.Place;
       await _context.SaveChangesAsync();
       return NoContent();
    }

    // Supprime un Héro de la Liste
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Hero>>> DeleteHero(int id)
    {
        var heroToDelete = await _context.Heroes.FindAsync(id);
        _context.Remove(heroToDelete);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}