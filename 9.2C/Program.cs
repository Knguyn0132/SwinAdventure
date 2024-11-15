using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._2C
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
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
            **/

            Location mountain1 = new Location(new string[] { "mountain1" }, "Mountain 1", "first mountain");
            Location mountain2 = new Location(new string[] { "mountain2" }, "Mountain 2", "second mountain");
            Item sword = new Item(new string[] { "sword" }, "Excalibur", "a strong sword");
            mountain1.Inventory.Put(sword);


            Paths pathToMountain1 = new Paths(new string[] { "west" }, "Journey to the West", "path leading West", mountain1);
            Paths pathToMountain2 = new Paths(new string[] { "east" }, "Journey to the East", "path leading East", mountain2);

            mountain1.AddPath(pathToMountain2);
            mountain2.AddPath(pathToMountain1);

            Player player = new Player("Wukong", "The monkey");
            player.Location = mountain1;
            player.Location = mountain2;

            MoveCommand moveCommand = new MoveCommand();
            while (true)
            {
                Console.WriteLine(player.Location.FullDescription);
                Console.Write("Enter command: ");
                string input = Console.ReadLine();
                string[] commandWords = input.Split(' '); //split into [0] and [1]
                string result = moveCommand.Execute(player, commandWords);
                Console.WriteLine(result);
            }

        }
    }
}
