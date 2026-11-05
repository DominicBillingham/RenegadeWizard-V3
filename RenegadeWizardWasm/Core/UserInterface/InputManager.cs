using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.UserInterface;

public class InputManager(SceneManager sceneManager)
{
    public ActionId? ChosenAction { get; set; }
    public List<Entity> ChosenTargets { get; set; } = new List<Entity>();

    public void ProcessInput(string userInput)
    {
        string[] userInputChunks = new string(userInput
                .Where(c => !char.IsPunctuation(c))
                .ToArray())
            .Trim()
            .ToLower()
            .Split(" ")
            .Where(x => x.Length > 2)
            .ToArray();

        foreach (string chunk in userInputChunks)
        {
            if (ChosenAction is null)
            { 
                foreach (ActionId action in Enum.GetValues(typeof(ActionId)))
                {
                    if (FuzzyMatch(action.ToString(), chunk))
                    {
                        ChosenAction = action;
                        break;
                    }
                }
            }
            
            foreach (Entity entity in sceneManager.Entities)
            {
                if (FuzzyMatch(entity.Name, chunk))
                {
                    ChosenTargets.Add(entity);
                }
            }
        }
        
    }

    public bool FuzzyMatch(string keyword, string input)
    {
        int distance = LevenshteinDistance(keyword, input);
        if (distance <= 1)
        {
            return true;
        }
        return false;
    }
    
    private int LevenshteinDistance(string a, string b)
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