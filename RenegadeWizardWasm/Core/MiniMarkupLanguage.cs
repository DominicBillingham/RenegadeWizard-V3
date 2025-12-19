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
}