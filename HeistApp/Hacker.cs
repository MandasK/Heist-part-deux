using System;

namespace HeistApp
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore = bank.AlarmScore - SkillLevel;
            // Mr. Pink is hacking the alarm system. Decreased security 50 points"
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points.");
            // Mr Pink has disabled the alarm system!
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }

        public void RolodexReport()
        {
            Console.WriteLine($"{Name}: Hacker, Skill Level: {SkillLevel}, Take: {PercentageCut}%");
        }
    }
}