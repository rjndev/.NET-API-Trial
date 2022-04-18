using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API_Trial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private static List<Pokemon> pokemons = new List<Pokemon>() {

                new Pokemon() { Name = "Pikachu", Id = 1, Region ="Johto", Level = 1},
                new Pokemon() { Id = 2, Name = "Squirtle", Level = 1, Region="Johto"}
            };


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(pokemons);
        }

        [HttpPost]
        public async Task<IActionResult> AddPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
            return Ok(pokemons);
        }

        [HttpGet]
        [Route("getPokemon/{id}")]
        public async Task<IActionResult> GetPokemon(int id)
        {
            //get single pokemon
            var pokemon = pokemons.Find(curr => curr.Id == id);
            if (pokemon == null) 
                return NotFound("Pokemon not found");
            return Ok(pokemon);

        }

        [HttpPut]
        public async Task<IActionResult> UpdatePokemon(Pokemon mon)
        {
            var pokemon = pokemons.Find(curr => curr.Id == mon.Id);
            if (pokemon == null)
                return NotFound("Pokemon not Found.");

            pokemon.Name = mon.Name;
            pokemon.Id = mon.Id;
            pokemon.Level = mon.Level;
            pokemon.Region = mon.Region;   


            return Ok(pokemons);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var pokemon = pokemons.Find(curr => curr.Id == id);
            if (pokemon == null)
                return NotFound("Pokemon Not Found");

            pokemons.Remove(pokemon);

            return Ok(pokemons);
        }

    }
}
