using System.Text;
using System.Text.RegularExpressions;

namespace RenegadeWizardWasm.Core;

public class MML
{
    
    
    private readonly Dictionary<string, string> StyleMap = new()
    {
        { "pk", "color:#FF77D1;" },
        { "gn", "color:#77FFAA;" },
        { "yw", "color:#FFFF99;" },
        { "be", "color:#77DDFF;" },
        { "og", "color:#FFBB66;" },
        { "pe", "color:#C488FF;" },
        { "rd", "color:#FF7777;" },
        { "ic", "font-style:italic;" },
        { "bd", "font-weight:bold;" },
        
    };

    public string WordReplacement(string input)
    {
        var random = new Random();
        var pattern = @"<([^>]+)>";
    
        return Regex.Replace(input, pattern, match =>
        {
            var word = match.Groups[1].Value.ToLower();
        
            if (word == "powerfully")
                return Powerfully[random.Next(Powerfully.Length)];
            if (word == "loudly")
                return Loudly[random.Next(Loudly.Length)];
            if (word == "carefully")
                return Carefully[random.Next(Carefully.Length)];
            if (word == "delicate")
                return Delicate[random.Next(Delicate.Length)];
            if (word == "ugly")
                return Ugly[random.Next(Ugly.Length)];
        
            return match.Value;
        });
    }
    
    // Adverbs
    private readonly string[] Powerfully = new[] { "powerfully", "mightily", "forcefully", "vigorously", "intensely", "strongly", "potently", "dynamically", "robustly", "energetically", "decisively", "formidably", "effectively", "dominantly", "overwhelmingly", "emphatically", "authoritatively", "commandingly", "impressively", "resoundingly" };
    private readonly string[] Loudly = new[] { "loudly", "noisily", "boisterously", "thunderously", "deafeningly", "vociferously", "clamorously", "uproariously", "stridently", "sonorously", "resonantly", "piercingly", "raucously", "booming", "bellowing", "roaring", "blaring", "howling", "shrieking", "screaming" };
    private readonly string[] Carefully = new[] { "carefully", "cautiously", "meticulously", "precisely", "diligently", "attentively", "thoroughly", "vigilantly", "prudently", "mindfully", "warily", "deliberately", "fastidiously", "methodically", "scrupulously", "conscientiously", "painstakingly", "watchfully", "exactingly", "studiously" };
    
    // Adjectives
    private readonly string[] Delicate = new[] { "delicate", "fragile", "dainty", "subtle", "refined", "elegant", "graceful", "ethereal", "gossamer", "fine", "exquisite", "sensitive", "frail", "tender", "light", "silken", "intricate", "airy", "flimsy", "gentle" };
    private readonly string[] Ugly = new[] { "ugly", "hideous", "grotesque", "repulsive", "unsightly", "revolting", "ghastly", "monstrous", "disfigured", "repugnant", "horrid", "gruesome", "deformed", "frightful", "misshapen", "offensive", "unpleasant", "odious", "atrocious", "terrible" };
    
    public string Html(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        if (!input.Contains('#'))
        {
            return input;
        }

        if (input.First() != '#')
        {
            input = "#" + input;
        }

        //var pattern = @"#([a-z]*)\s*([^#]*)";
        var pattern = @"#([a-z0-9]*)\s*([^#]*)";

        var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
        var sb = new StringBuilder();

        foreach (Match match in matches)
        {
            string tags = match.Groups[1].Value;
            string content = match.Groups[2].Value.TrimStart();

            var styles = new StringBuilder();

            foreach (var tag in StyleMap)
            {
                if (tags.Contains(tag.Key))
                {
                    styles.Append(tag.Value);
                }
            }

            sb.Append($"<span  style='{styles}'>{content}</span>");
        }

        return sb.ToString();
    }
    
    // Word Libraries:
    
    
    
}