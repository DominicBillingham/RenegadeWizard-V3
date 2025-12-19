namespace RenegadeWizardWasm.Core;

public class InputManager(SceneManager sceneManager)
{
    public GameAction? chosenAction { get; set; }
    public void ProcessInput(string userInput)
    {
        string[] userInputChunks = new string(userInput
            .Where(c => !char.IsPunctuation(c))
            .ToArray())
            .Trim()
            .ToLower()
            .Split(" ")
            .Where(x => x.Length > 2 || x == "go")
            .ToArray();
        
        chosenAction = sceneManager.Player.Actions.
            FirstOrDefault(action => FuzzyMatch(action.Names, userInputChunks));
        
        if (chosenAction == null) return;
        
        chosenAction.Actor = sceneManager.Player;
        
        chosenAction.Targets = sceneManager.Entities
            .Where(entity => FuzzyMatch(entity.Names, userInputChunks))
            .ToList();
    }

    public bool FuzzyMatch(string keyword, IEnumerable<string> input)
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
    
    public bool FuzzyMatch(IEnumerable<string> keywords, IEnumerable<string> input)
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