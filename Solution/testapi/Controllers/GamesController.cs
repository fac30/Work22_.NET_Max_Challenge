using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers;

[ApiController]
[Route("[controller]")]

public class GamesController : ControllerBase
{
    private static List<Game> games;

// demo has this bellow methods  I cant imagine why thoe order would matter though keep it in mind
   public class Game{
        public int id { get; set; }
        public string? teamOneName { get; set; }
        public string? teamTwoName { get; set; }
        public int winner { get; set; } 

   } 
    List<Game> PopulateGames(){
        return new List<Game>
        {
            new Game{
               id = 1,
               teamOneName="London",
               teamTwoName="Cardif",
               winner =1  
            },
             new Game{
               id = 2,
               teamOneName="Leeds",
               teamTwoName="London",
               winner =2  
            },
             new Game{
               id = 3,
               teamOneName="London",
               teamTwoName="Manchester",
               winner =1  
            },
        };
    }

    private readonly ILogger<GamesController> _logger;

    public GamesController(ILogger<GamesController> logger)
    {
        games = PopulateGames();
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Game> Get()
    {
        return games;
    }
    
        [HttpDelete]
        public IEnumerable<Game> Delete( int id)
        {
            var game = games.FirstOrDefault(x => x.id == id);
            if (game != null) games.Remove(game);
            return games;
        }
                [HttpPost]
        public IEnumerable<Game>  AddGame(Game game)
        {
            games.Add(game);
            return games;
        }
}
