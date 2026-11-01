using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.UserInterface;

public static class InputManager
{
    public static ActionNames? chosenAction { get; set; }
    public static void ProcessInput(string userInput)
    {
        string[] userInputChunks = new string(userInput
            .Where(c => !char.IsPunctuation(c))
            .ToArray())
            .Trim()
            .ToLower()
            .Split(" ")
            .Where(x => x.Length > 2)
            .ToArray();

        foreach (ActionNames action in Enum.GetValues(typeof(ActionNames)))
        {
            if (FuzzyMatch(action.ToString(), userInputChunks))
            {
                chosenAction = action;
                break;
            }
        }
        
    }
    
    public static bool FuzzyMatch(string keyword, IEnumerable<string> input)
    {
        foreach (var inputWord in input)
        {
            int distance = LevenshteinDistance(inputWord, keyword);

            if (distance <= 1)
            {
                return true;
            }
        }

        return false;
    }
    
    public static bool FuzzyMatch(IEnumerable<string> keywords, IEnumerable<string> input)
    {
        foreach (var inputWord in input)
        {
            foreach (var keyword in keywords)
            {
                int distance = LevenshteinDistance(inputWord, keyword);

                if (distance <= 1)
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    private static int LevenshteinDistance(string a, string b)
    {
        a = a.ToLower();
        b = b.ToLower();

        int[,] dp = new int[a.Length + 1, b.Length + 1];

        for (int i = 0; i <= a.Length; i++)
            dp[i, 0] = i;
        for (int j = 0; j <= b.Length; j++)
            dp[0, j] = j;

        for (int i = 1; i <= a.Length; i++)
        {
            for (int j = 1; j <= b.Length; j++)
            {
                int cost = a[i - 1] == b[j - 1] ? 0 : 1;

                dp[i, j] = Math.Min(
                    Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                    dp[i - 1, j - 1] + cost
                );
            }
        }

        return dp[a.Length, b.Length];
    }
}