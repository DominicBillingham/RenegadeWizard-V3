using RenegadeWizard.Classes.Nodes;
using RenegadeWizard.Classes.Enums;

namespace RenegadeWizard.Classes.Data
{
    public class CommandResponse
    {
        // One commandResponse object is created and then returned in response to a user input.

        public List<string> FormatStrings { get; set; } = new();
        public List<string> ActionStrings { get; set; } = new();
        public List<string> SkillStrings { get; set; } = new();
        public List<string> TextStrings { get; set; } = new();
        public List<string> DamageStrings { get; set; } = new();

        public List<string> ConsoleLines
        {
            get
            {
                List<string> list = new List<string>();
                list.AddRange(FormatStrings);
                list.AddRange(ActionStrings);
                list.AddRange(SkillStrings);
                list.AddRange(TextStrings);
                list.AddRange(DamageStrings);
                return list;
            }
        }

        public string SourceName { get; set; }
        public int DeterminationDamage { get; set; }
        public Node NewNode { get; set; }


        public int? ItemCheckDifficulty { get; set; }
        public Property ItemCheckProperty { get; set; }
        public CommandResponse? ItemCheckFail  { get; set; }

        // Skill Checks
        public int? SkillCheckDifficulty { get; set; }
        public Skill SkillCheckAttribute { get; set; }
        public Property SkillCheckProperty { get; set; }
        public CommandResponse? SkillCheckFail { get; set; } 

        // VFX, SFX
        public string Audio { get; set; } = string.Empty;
        public bool OverrideAudio {  get; set; } = false;
        public string ConsoleAnimation { get; set; } = string.Empty;

    }
}
