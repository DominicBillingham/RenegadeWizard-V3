using System.Text;
using System.Text.RegularExpressions;

namespace RenegadeWizardWasm.Core.UserInterface;

public class MML
{
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
            input = "# " + input;
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
            var classes = new StringBuilder();

            foreach (var tag in StyleMap)
            {
                if (tags.Contains(tag.Key))
                {
                    styles.Append(tag.Value);
                }
            }
            
            foreach (var tag in ClassMap)
            {
                if (tags.Contains(tag.Key))
                {
                    classes.Append($"{tag.Value} ");
                }
            }
            
            sb.Append($"<span class='{classes}'  style='{styles}'>{content}</span>");
        }

        return sb.ToString();
    }
    
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
        {  "bg", "font-size:5vh;"}
        
    };
    
    private readonly Dictionary<string, string> ClassMap = new()
    {
        { "shk", "shake" },
        { "pls", "pulse" },
        { "bnc", "bounce" },
        { "glw", "glow" },
        { "flk", "flicker" },
        { "spn", "spin" },
        { "wbl", "wobble" },
        { "fad", "fade" },
        { "sld", "slide" },
        { "wav", "wave" },
        { "rnb", "rainbow" },
        { "grw", "grow" },
        { "jtr", "jitter" },
        { "blk", "blink" },
        { "flt", "float" },
        { "swg", "swing" },
        { "flp", "flip" },
        { "vbr", "vibrate" },
        { "zm", "zoom" },
        { "sqz", "squeeze" },
        { "skw", "skew" },
        { "els", "elastic" },
        { "crs", "cursor" },
        { "shm", "shimmer" },
        { "nen", "neon" },
        { "glt", "glitch" },
        { "narr", "narration"}
        
    };
    
    public string WordReplacement(string input)
    {
        var random = new Random();
        var pattern = @"<([^>]+)>";
        
        var wordMap = new Dictionary<string, string[]>
        {
            // Adverbs
            { "powerfully", new[] { "powerfully", "mightily", "forcefully", "vigorously", "intensely", "strongly", "potently", "dynamically", "robustly", "energetically", "decisively", "formidably", "effectively", "dominantly", "overwhelmingly", "emphatically", "authoritatively", "commandingly", "impressively", "resoundingly" } },
            { "loudly", new[] { "loudly", "noisily", "boisterously", "thunderously", "deafeningly", "vociferously", "clamorously", "uproariously", "stridently", "sonorously", "resonantly", "piercingly", "raucously", "booming", "bellowing", "roaring", "blaring", "howling", "shrieking", "screaming" } },
            { "carefully", new[] { "carefully", "cautiously", "meticulously", "precisely", "diligently", "attentively", "thoroughly", "vigilantly", "prudently", "mindfully", "warily", "deliberately", "fastidiously", "methodically", "scrupulously", "conscientiously", "painstakingly", "watchfully", "exactingly", "studiously" } },
            { "delicate", new[] { "delicate", "fragile", "dainty", "subtle", "refined", "elegant", "graceful", "ethereal", "gossamer", "fine", "exquisite", "sensitive", "frail", "tender", "light", "silken", "intricate", "airy", "flimsy", "gentle" } },
            { "ugly", new[] { "ugly", "hideous", "grotesque", "repulsive", "unsightly", "revolting", "ghastly", "monstrous", "disfigured", "repugnant", "horrid", "gruesome", "deformed", "frightful", "misshapen", "offensive", "unpleasant", "odious", "atrocious", "terrible" } },
            
            // Connectors
            { "however", new[] { "however", "nevertheless", "nonetheless", "yet", "still", "though", "although", "even so", "be that as it may", "in spite of that", "despite that", "on the other hand", "conversely", "in contrast", "that said", "having said that", "at the same time", "notwithstanding", "all the same", "regardless" } },
            { "and", new[] { "and", "also", "furthermore", "moreover", "additionally", "plus", "as well as", "along with", "together with", "in addition", "besides", "likewise", "similarly", "equally", "correspondingly", "not to mention", "coupled with", "what's more", "on top of that", "too" } },
            
            // Narrations!
            { "wtf", new[] {"What the FUCK.", "Why on this cursed Earth?", "Has god forsaken us?", "Some of this shit I have to describe...", "How did we get here?", "Well, that happened." } },
            { "ouch", new[] { "Youch", "Oof", "F", "That's gonna hurt tomorrow", "YOWIE", "I'll let the graveyard know..." } },
            { "gross", new[] { "Disgusting.", "Ew.", "That cannot be healthy.", "Yuck."} },
            { "obvious", new[] { "Obviously.", "Duh.", "Naturally.", "What did you think was going to happen?"}},
            
            // Actions
            { "fails", new[] {"Flops completely.", "But it's a complete disaster.", "Fails miserably.", "But it end's up failing, like everything they do.", "Naturally they fuck it up."}},
            
            { "template", new[] { "template1.",  "template2.", "template3.", "template4.", "template5." }}

        }; 
    
        return Regex.Replace(input, pattern, match =>
        {
            var word = match.Groups[1].Value.ToLower();
        
            if (wordMap.TryGetValue(word, out var replacements))
                return replacements[random.Next(replacements.Length)];
        
            return match.Value;
        });
    }

    
}