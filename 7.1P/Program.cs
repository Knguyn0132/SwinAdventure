using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1P
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine("Enter your description: ");
            string playerDescription = Console.ReadLine();
            Player player = new Player(playerName, playerDescription);

            Item sword = new Item(new string[] {"sword"}, "Excalibur", "a strong sword");
            Item shield = new Item(new string[] {"shield"}, "Aegis", "a strong shield");
            
            player.Inventory.Put(sword);
            player.Inventory.Put(shield);

            Bag backpack = new Bag(new string[] { "backpack" }, "Adidas", "a big backpack");
            player.Inventory.Put(backpack);
            Item gem = new Item(new string[] { "gem" }, "Ruby", "a rare gem");
            backpack.Inventory.Put(gem);

            /////
            LookCommand lookCommand = new LookCommand();
            while (true) 
            {
                Console.Write("What do you want to look at?: "); 
                string input = Console.ReadLine(); 
                string[] commandWords = input.Split(' '); 
                string result = lookCommand.Execute(player, commandWords); 
                Console.WriteLine(result);
            }

        }
    }
}
