using System;
using System.Collections.Generic;
using System.Text;

namespace _09
{
    public class Trainer
    {
        public string Name{ get; set; }
        public int Badges { get; set; }
        public List<Pokemon>  Pokemons{ get; set; }
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }
        public void AddPokemon(Pokemon pokemon) { this.Pokemons.Add(pokemon); }
        public void DecrementEveryPokemon()
        {
            List<Pokemon> toRemove= new List<Pokemon>();
           
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
                if (pokemon.Health<=0)
                {
                    toRemove.Add(pokemon);
                }
            }
            foreach (var item in toRemove)
            {
                Pokemons.Remove(item);
            }
        }
    }
}
