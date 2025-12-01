using System.Text.RegularExpressions;
using System.Text;

namespace RenegadeWizard.Classes.Utility
{
    public class MML
    {
        private static readonly Dictionary<string, string> StyleMap = new()
        {
            { "pin", "color:#FF77D1;" },
            { "grn", "color:#77FFAA;" },
            { "ylw", "color:#FFFF99;" },
            { "blu", "color:#77DDFF;" },
            { "org", "color:#FFBB66;" },
            { "pur", "color:#C488FF;" },
            { "red", "color:#FF7777;" },
            { "cyn", "color:#66FFFF;" },
            { "mag", "color:#FF66CC;" },


            { "itc", "font-style:italic;" },
            { "bol", "font-weight:bold;" },

            { "f1", "font-size:2.5rem;" },
            { "f2", "font-size:2rem;" },
            { "f3", "font-size:1.75rem;" },
            { "f4", "font-size:1.5rem;" },
            { "f5", "font-size:1.25rem;" },
            { "f6", "font-size:1rem;" },
            { "f7", "font-size:0.85rem;" },

            { "item", "color:#FFBB66;" },
            { "noun", "color:#FFFF99;" },
            { "verb", "color:#77FFAA;" },
            { "node", "color:#FF77D1;" },
            { "info", "color:#77DDFF;" },
            { "name", "font-style: bold;" },

            { "mono", "font-style: italic;" },

            { "lysa", "font-family: \"Lobster Two\", sans-serif; font-size: 21px;" },
            { "just", "  font-family: \"Cinzel\", serif; font-weight: 400;" },
            { "grub", "  font-family: \"Permanent Marker\", cursive; font-size: 21px;" },
            { "sond", "  font-family: \"Kaushan Script\", cursive; font-size: 21px;" },
            { "halc", "font-style: italic;" },



        };

        public static string Html(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

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

                sb.Append($"<span class='console-line' style='{styles}'>{content}</span>");
            }

            return sb.ToString();
        }
    }
}
