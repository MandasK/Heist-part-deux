using System;
using System.Collections.Generic;

namespace HeistApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Hacker haxxor = new Hacker()
            {
                Name = "Andy",
                SkillLevel = 99,
                PercentageCut = 33
            };
            Hacker haxxor2 = new Hacker()
            {
                Name = "Mo",
                SkillLevel = 88,
                PercentageCut = 33
            };
            LockSpecialist unlock = new LockSpecialist()
            {
                Name = "Tyler",
                SkillLevel = 99,
                PercentageCut = 33
            };
            LockSpecialist unlock2 = new LockSpecialist()
            {
                Name = "Brandon",
                SkillLevel = 88,
                PercentageCut = 33
            };
            Muscle braun = new Muscle()
            {
                Name = "Patrick",
                SkillLevel = 99,
                PercentageCut = 33
            };
            Muscle braun2 = new Muscle()
            {
                Name = "Lacey",
                SkillLevel = 88,
                PercentageCut = 33
            };

            List<IRobber> rolodex = new List<IRobber>()
            {
                haxxor,
                haxxor2,
                unlock,
                unlock2,
                braun,
                braun2
            };

            Console.WriteLine("Bank Heist");
            Console.WriteLine("-----------------");
            Console.WriteLine("Team Member Options");
            rolodex.ForEach(robber => Console.WriteLine($"{robber.Name} has skill level {robber.SkillLevel} and gets {robber.PercentageCut}% of the take."));
        }
    }
}