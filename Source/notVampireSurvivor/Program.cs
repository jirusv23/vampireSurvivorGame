using notVampireSurvivor;
using System;
using System.Threading.Tasks;

public static class Program
{
    static void Main()
    {
        using var game = new Game1();
        game.Run();
    }
}
