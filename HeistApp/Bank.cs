using System;

namespace HeistApp
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }

        public bool IsSecure

        {
            get
            {
                return SecurityGuardScore < 1 && VaultScore < 1 && AlarmScore < 1;
            }
        }

        public void ReconReport()

        {
            Console.WriteLine("Bank Report");
            Console.WriteLine();
            if (AlarmScore > VaultScore && AlarmScore > SecurityGuardScore)
            {
                Console.WriteLine("Most secure: Alarm");
            }
            else if (VaultScore > AlarmScore && VaultScore > SecurityGuardScore)
            {
                Console.WriteLine("Most secure: Vault");
            }
            else
            {
                Console.WriteLine("Most secure: Security");
            }

            if (AlarmScore < VaultScore && AlarmScore < SecurityGuardScore)
            {
                Console.WriteLine("Least secure: Alarm");
            }
            else if (VaultScore < AlarmScore && VaultScore < SecurityGuardScore)
            {
                Console.WriteLine("Least secure: Vault");
            }
            else
            {
                Console.WriteLine("Least secure: Security");
            }
            Console.WriteLine("--------------------");
        }
    }
}