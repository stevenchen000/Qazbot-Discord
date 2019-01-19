using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Qazbot.CommandSystem
{
    public class CommandManager
    {
        public List<Command> commands { get; set; }
        private Dictionary<string, Command> commandsDict;
        
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
                List<string> commandNames = new List<string>();
                commandNames.Add(commands[i].commandName);
                commandNames.AddRange(commands[i].aliases);
                
                for(int j = 0; j < commandNames.Count; j++)
                {
                    string commName = commandNames[j];

                    if (!commandsDict.ContainsKey(commName)) {
                        commandsDict[commName] = commands[i];
                    }
                }
            }
        }

        public void CallCommand(string commandName) {
            if (commandsDict.ContainsKey(commandName)) {
                commandsDict[commandName].Call();
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