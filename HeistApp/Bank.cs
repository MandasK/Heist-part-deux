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

    }
}