namespace _03_OOP
{
    class Zak
    {
        // co kazdy zak zna
        private string Jmeno;
        private string Prijmeni;

        // jak kazdy zak vznika
        public Zak(string jmeno, string prijmeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
        }

        // co kazdy zak umi
        public string RekniSvojeCeleJmeno()
        {
            return Jmeno + " " + Prijmeni;
        }
    }
}
