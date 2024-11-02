using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers;

[ApiController]
[Route("[controller]")]

public class GamesController : ControllerBase
{
    private static List<Game>? games;

// demo has this bellow methods  I cant imagine why thoe order would matter though keep it in mind

   public class Game{
        public int Id { get; set; }
        public string? TeamOneName { get; set; }
        public string? TeamTwoName { get; set; }
        public int Winner { get; set; } 

   }

    static List<Game> PopulateGames(){
        return
        [
            new Game{
               Id = 1,
               TeamOneName="London",
               TeamTwoName="Cardif",
               Winner =1  
            },
             new Game{
               Id = 2,
               TeamOneName="Leeds",
               TeamTwoName="London",
               Winner =2  
            },
             new Game{
               Id = 3,
               TeamOneName="London",
               TeamTwoName="Manchester",
               Winner =1  
            },
        ];
    }

    private readonly ILogger<GamesController> _logger;

    public GamesController(ILogger<GamesController> logger)
    {
        games = PopulateGames();
        _logger = logger;
    }

    [HttpGet]
    public List<Game>? Get() 
    {
        return games;
    }
    
        [HttpDelete]
        public List<Game>? Delete( int id)
        {
            if (games == null) return null;
    
            var gameToDelete = games.FirstOrDefault(g => g.Id == id);
            if (gameToDelete != null) games.Remove(gameToDelete);
            
            return games;
        }
                [HttpPost]
        public IEnumerable<Game>? AddGame( Game game)
        {
            if (games == null) return null;
            games.Add(game);
            return games;
        }
}
