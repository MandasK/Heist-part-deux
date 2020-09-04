using System;

namespace HeistApp
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
            // Mr. Pink is hacking the alarm system. Decreased security 50 points"
            Console.WriteLine($"{Name} is taking out the security guard. Decreased security {SkillLevel} points.");
            // Mr Pink has disabled the alarm system!
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the security guard!");
            }
        }
    }
}