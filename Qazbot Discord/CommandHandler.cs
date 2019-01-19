using System;
using System.Collections.Generic;

public class CommandHandler
{

    private Dictionary<string, Command> allCommands = new Dictionary<string, Command>();

	public CommandHandler()
	{

	}


    public void DoCommand(string username, string message) {
        string keyword = message.Split(" ")[0];

        if (allCommands.ContainsKey(keyword)) {
            allCommands[keyword];
        }

    }

}
