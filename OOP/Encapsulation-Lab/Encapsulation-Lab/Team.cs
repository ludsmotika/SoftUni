﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private  List<Person> firstTeam;
        private  List<Person> reserveTeam;
        public IReadOnlyCollection<Person> FirstTeam => this.firstTeam.AsReadOnly();
        public IReadOnlyCollection<Person> ReserveTeam => this.reserveTeam.AsReadOnly();
        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }
        public void AddPlayer(Person person)
        {
            if (person.Age<40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
