using System;
namespace HeistApp
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.VaultScore = bank.VaultScore - SkillLevel;
            // Mr. Pink is hacking the alarm system. Decreased security 50 points"
            Console.WriteLine($"{Name} is picking the vault Lock. Decreased security {SkillLevel} points.");
            // Mr Pink has disabled the alarm system!
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has unlocked the vault!");
            }
        }
        public void RolodexReport()
        {
            Console.WriteLine($"{Name}: Lock Specialist, Skill Level: {SkillLevel}, Take: {PercentageCut}%");
        }
    }

}