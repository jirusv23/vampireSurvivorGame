namespace _03_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Zak> zaci = new List<Zak>();

            zaci.Add(new Zak("Jan", "Novák"));
            zaci.Add(new Zak("Jana", "Nováková"));
            zaci.Add(new Zak("Jiří", "Nezamysl"));

            foreach(Zak zak in zaci)
            {
                Console.WriteLine(zak.RekniSvojeCeleJmeno());
            }
        }
    }
}
