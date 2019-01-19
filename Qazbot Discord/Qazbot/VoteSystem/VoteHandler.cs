using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class VoteHandler
{

    Dictionary<string, int> votes = new Dictionary<string, int>();
    public List<string> options { get; set; } = new List<string>();
    public string pollTitle;

    private bool voteStarted = false;

    public VoteHandler() {

    }

    public VoteHandler(string title, List<string> options) {
        this.options = options;
        pollTitle = title;
    }


    /// <summary>
    /// Open up voting
    /// </summary>
    public bool OpenVotes() {
        if (options.Count >= 2)
        {
            voteStarted = true;
        }
        else {
            //must have at least 2 options
        }

        return voteStarted;
    }


    /// <summary>
    /// Stops a vote. Does not reset a vote, does not calculate total votes.
    /// </summary>
    public void StopVote() {
        voteStarted = false;
    }


    /// <summary>
    /// Resets the poll 
    /// </summary>
    public void ResetPoll() {
        ResetVotes();
        ResetOptions();
    }


    /// <summary>
    /// Add an option while a poll is closed
    /// </summary>
    /// <param name="option"></param>
    public void AddOption(string option) {
        if (!voteStarted) {
            options.Add(option);
        }
    }


    /// <summary>
    /// Removes an option at the specified index
    /// </summary>
    /// <param name="index"></param>
    public void RemoveOption(int index) {
        if (options.Count > index && index > 0) {
            options.RemoveAt(index);
        }
    }


    /// <summary>
    /// Add a vote while the poll is open
    /// </summary>
    /// <param name="username"></param>
    /// <param name="option"></param>
    public void Vote(string username, int option) {
        if (option < options.Count && option >= 0 && voteStarted)
        {
            votes[username] = option;
        }
    }


    /// <summary>
    /// Removes the person's vote
    /// </summary>
    /// <param name="username"></param>
    public void RemoveVote(string username) {
        if (votes.ContainsKey(username)) {
            votes.Remove(username);
        }
    }


    /// <summary>
    /// Returns a string indicating who won
    /// </summary>
    /// <returns></returns>
    public string AnnounceWinner() {
        List<int> totalVotes = CountVotes();
        List<int> winners = GetHighestIndices(totalVotes);

        string result = "";

        if (winners.Count == 1)
        {
            result = $"The winner with {totalVotes[winners[0]]} votes is {options[winners[0]]}!";
        }
        else {
            result = $"There is a tie! The winners with {totalVotes[winners[0]]} votes are ";
            for(int i = 0; i < winners.Count; i++) {
                if (i == winners.Count - 1)
                {
                    result += $"{options[winners[i]]}.";
                }
                else
                {
                    result += $"{options[winners[i]]}, ";
                }
            }
        }

        return result;
    }


    /// <summary>
    /// Counts the total number of votes for each option
    /// </summary>
    /// <returns></returns>
    private List<int> CountVotes() {
        List<int> totalVotes = new List<int>();
        
        //init totalVotes
        for (int i = 0; i < options.Count; i++) {
            totalVotes.Add(0);
        }

        //count votes
        foreach (int vote in votes.Values) {
            totalVotes[vote]++;
        }

        return totalVotes;
    }


    /// <summary>
    /// Grabs all indices with the highest value
    /// </summary>
    /// <param name="totalVotes"></param>
    /// <returns></returns>
    private List<int> GetHighestIndices(List<int> totalVotes) {
        List<int> result = new List<int>();
        int highest = totalVotes.Max();

        for (int i = 0; i < totalVotes.Count; i++) {
            if (totalVotes[i] == highest) {
                result.Add(i);
            }
        }

        return result;
    }


    public void ResetVotes() {
        votes = new Dictionary<string, int>();
    }

    public void ResetOptions() {
        options = new List<string>();
    }
    
}

