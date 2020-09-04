using System;
using System.Collections.Generic;

namespace HeistApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank Heist");
            Console.WriteLine("-----------------");

            bool membercheck = true;
            bool crewcheck = true;
            int totaltake = 100;
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

            List<IRobber> crew = new List<IRobber>();

            Console.WriteLine($"You currently have {rolodex.Count} people in your rolodex of thieves");
            Console.WriteLine("Add more thieves if you have them");

            while (membercheck)
            {
                Console.Write("What's the Name of the Thief? ");
                string Name = Console.ReadLine();
                if (Name == "")
                {
                    membercheck = false;
                }
                else
                {
                    Console.WriteLine("Choose a Specialty(Number):");
                    Console.WriteLine("1. Hacker(Disables Alarms)\n2. LockSpecialist(Cracks Vault)\n3. Muscle(Disarms Guards)\n");
                    string specialty = Console.ReadLine();
                    switch (specialty)
                    {
                        case "1":
                            Hacker aHacker = new Hacker();
                            aHacker.Name = Name;
                            Console.Write("What would you say this hacker's skill level is (1-100)? ");
                            aHacker.SkillLevel = int.Parse(Console.ReadLine());
                            Console.Write("What's their take of the money(1-100)? ");
                            aHacker.PercentageCut = int.Parse(Console.ReadLine());
                            rolodex.Add(aHacker);
                            break;

                        case "2":
                            LockSpecialist aLockSpecialist = new LockSpecialist();
                            aLockSpecialist.Name = Name;
                            Console.Write("What would you say this lock specialist's skill level is (1-100)? ");
                            aLockSpecialist.SkillLevel = int.Parse(Console.ReadLine());
                            Console.Write("What's their take of the money(1-100)? ");
                            aLockSpecialist.PercentageCut = int.Parse(Console.ReadLine());
                            rolodex.Add(aLockSpecialist);
                            break;

                        case "3":
                            Muscle aMuscle = new Muscle();
                            aMuscle.Name = Name;
                            Console.Write("What would you say this Muscle's skill level is (1-100)? ");
                            aMuscle.SkillLevel = int.Parse(Console.ReadLine());
                            Console.Write("What's their take of the money(1-100)? ");
                            aMuscle.PercentageCut = int.Parse(Console.ReadLine());
                            rolodex.Add(aMuscle);
                            break;
                    }
                }
            }

            Bank aBank = new Bank();
            aBank.CashOnHand = new Random().Next(50000, 1000000);
            aBank.AlarmScore = new Random().Next(0, 101);
            aBank.VaultScore = new Random().Next(0, 101);
            aBank.SecurityGuardScore = new Random().Next(0, 101);
            aBank.ReconReport();

            Console.WriteLine("Team Member Options");
            Console.WriteLine();

            foreach (IRobber thief in rolodex)
            {
                int num = rolodex.IndexOf(thief);
                Console.Write($"{num}  ");
                thief.RolodexReport();
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("Time to pick ");
            while (crewcheck)
            {
                Console.Write("Who do you want to join your crew?");
                string amember = Console.ReadLine();
                if (amember == "")
                {
                    crewcheck = false;
                }
                else
                {
                    int aMemNum = int.Parse(amember);
                    crew.Add(rolodex[aMemNum]);
                    totaltake = totaltake - rolodex[aMemNum].PercentageCut;
                    Console.WriteLine($"{totaltake}");
                    rolodex.RemoveAt(aMemNum);
                    foreach (IRobber thief in rolodex)
                    {
                        if (thief.PercentageCut >= 0)
                        {
                            int num = rolodex.IndexOf(thief);
                            Console.Write($"{num}  ");
                            thief.RolodexReport();
                        }
                        else
                        {
                            int num = rolodex.IndexOf(thief);
                            Console.WriteLine("The Percentage is too high. We can't add this thief.");
                        }
                    }

                }

            }
            foreach (IRobber athief in crew)
            {
                athief.PerformSkill(aBank);
            }
            aBank.IsSecure();

            if (aBank.AlarmScore > 0 && aBank.VaultScore > 0 && aBank.SecurityGuardScore > 0)
            {
                Console.WriteLine("You failed. You didn't get the money, and you're in jail.");
            }
            else
            {
                Console.WriteLine("Success! We did it! We're rich!");
                int successTake = aBank.CashOnHand / 100;
                foreach (IRobber thief in crew)
                {
                    int thiefProfit = successTake * thief.PercentageCut;
                    Console.WriteLine($"{thief.Name} gets ${thiefProfit}");
                }

            }
        }
    }
}