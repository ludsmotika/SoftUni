using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public string Name{ get; set; }
        public int Power { get; set; }
        public BaseHero(string name,int power)
        {
            Name = name;
            Power = power;
        }
        public abstract string CastAbility();
    }
}
