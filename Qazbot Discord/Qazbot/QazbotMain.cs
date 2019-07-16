using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DSharpPlus;
using Newtonsoft.Json;
using DSharpPlus.CommandsNext;
using DSharpPlus.Net.WebSocket;
using Qazbot.AnimationSystem;
using Qazbot.FF9Nobles;
using Qazbot.VoteSystem;
using System.Runtime.Serialization.Formatters.Binary;
using Qazbot.CommandSystem;

namespace Qazbot
{
    public class QazbotMain
    {
        public static DiscordClient discord { get; set; }
        public static CommandsNextModule commandsNext { get; set; }
        public static BotManager client { get; set; }
        public static string tokenFilename = "BotToken.txt";

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            string token = readFile(tokenFilename);

            //create new client
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            TempAddModules temp = new TempAddModules();
            temp.AddModules();


            //create command module
            commandsNext = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!"
            });

            commandsNext.RegisterCommands<MyCommands>();
            commandsNext.RegisterCommands<AnimationCommands>();
            commandsNext.RegisterCommands<NoblesCommand>();
            commandsNext.RegisterCommands<VoteCommand>();


            /*
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };*/

            CommandManager commands = new CommandManager();
            //makes discord usable on Windows 7
            discord.SetWebSocketClient<WebSocketSharpClient>();
            discord.MessageCreated += commands.CheckCommand;
            await discord.ConnectAsync();
            await Task.Delay(-1);
            
        }


        public static void saveFile(string filename, string text) {

            FileStream stream = null;

            try
            {
                stream = new FileStream(filename, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, text);
                stream.Close();
            }
            catch {
                Console.WriteLine($"Error: Failed to write to {filename}");

                //Close the file if it is still open
                if (stream != null) {
                    stream.Close();
                }
            }
        }

        public static string readFile(string filename) {
            string result = "";
            FileStream stream = null;

            if (File.Exists(filename)) {
                try
                {
                    stream = new FileStream(filename, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    result = (string)bf.Deserialize(stream);
                    stream.Close();
                }
                catch {
                    Console.WriteLine($"Error: Failed to read from {filename}");

                    //Close the file if it is still open
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }

            return result;
        }

    }

}