using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System;
using DSharpPlus.EventArgs;

namespace Qazbot.CommandSystem
{
    public class CommandManager
    {
        public List<Command> commands { get; set; }
        private Dictionary<string, Command> commandsDict;
        public string prefix { get; set; } = "!";
        
        public string filename { get; set; } = "Commands.txt";

        public CommandManager() {
            LoadCommands();
            ListToDict();
        }

        /// <summary>
        /// Convert the list to a dictionary of commands
        /// </summary>
        private void ListToDict() {
            commandsDict = new Dictionary<string, Command>();

            for (int i = 0; i < commands.Count; i++) {
                //Get the command name first
                Command command = commands[i];
                if (!commandsDict.ContainsKey(command.commandName)) {
                    commandsDict[command.commandName] = commands[i];
                }
                else
                {
                    Console.WriteLine($"The command {command.commandName} already exists.");
                }

                //Apply aliases as well
                //NOTE: Might wanna separate this just so commands have higher precedence than aliases
                for (int j = 0; j < command.aliases.Count; j++) {
                    string alias = command.aliases[j];
                    if (!commandsDict.ContainsKey(alias))
                    {
                        commandsDict[alias] = command;
                    }
                    else {
                        Console.WriteLine($"The command {alias} already exists.");
                    }
                }
            }
        }



        public async Task CheckCommand(MessageCreateEventArgs args) {
            string message = args.Message.Content;
            if (message.StartsWith(prefix)) {
                message = message.Substring(1);
                string[] splitMessage = message.Split(' ');
                string command = splitMessage[0].ToLower();
                message = message.Substring(command.Length + 1);

                await CallCommand(command, message, args);
            }
        }


        public async Task CallCommand(string commandName, string message, MessageCreateEventArgs args) {
            if (commandsDict.ContainsKey(commandName)) {
                await commandsDict[commandName].Execute(message, args);
            }
        }

        public void SaveCommands() {
            FileHandler<List<Command>>.SaveFile(filename, commands);
        }

        public void LoadCommands() {
            commands = FileHandler<List<Command>>.ReadFile(filename);

            if (commands == null) {
                commands = new List<Command>();
            }
        }
    }
}