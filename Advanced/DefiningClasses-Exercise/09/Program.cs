using System;
using System.Collections.Generic;
using System.Linq;

namespace _09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string[] cmd=Console.ReadLine().Split(' ');
            while (cmd[0]!= "Tournament")
            {
                string trainerName = cmd[0];
                string pokemonName = cmd[1];
                string pokemonElement=cmd[2];
                int pokemonHealth=int.Parse(cmd[3]);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer currentTrainer = trainers.Find(x => x.Name == trainerName);
                if (currentTrainer==null)
                {
                     currentTrainer = new Trainer(trainerName);
                    trainers.Add(currentTrainer);
                }
                currentTrainer.AddPokemon(currentPokemon);
                cmd = Console.ReadLine().Split(' ');
            }
            string element = Console.ReadLine();
            while (element!="End")
            {
                foreach (var item in trainers)
                {
                    if (item.Pokemons.Find(x=>x.Element==element)!=null)
                    {
                        item.Badges++;
                    }
                    else
                    {
                        item.DecrementEveryPokemon();
                    }
                }
                element = Console.ReadLine();
            }
            trainers = trainers.OrderByDescending(x => x.Badges).ToList();
            foreach (var item in trainers)
            {
                Console.WriteLine( $"{item.Name} {item.Badges } {item.Pokemons.Count}");
            }
        }
    }
}
