using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._1C
{
    public class CommandProcessor 
    {
        private List<Command> _commands;


        public CommandProcessor() 
        {
            _commands = new List<Command>();
            _commands.Add(new LookCommand());
            _commands.Add(new MoveCommand());
        }

        public string ExecuteCommand(string commandText, Player player)
        {
            if (string.IsNullOrWhiteSpace(commandText))
            {
                return "Invalid command.";
            }

            
            string[] commandWords = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Split the input into words

            if (commandWords.Length == 0)
            {
                return "Invalid command.";
            }


            string commandKeyword = commandWords[0].ToLower();

            
            foreach (Command command in _commands)
            {
                if (command.AreYou(commandKeyword))
                {
                    return command.Execute(player, commandWords);
                }
            }

            return $"Unknown command: {commandKeyword}";
        }
    }
}
