using RenegadeWizard.Classes.Nodes;

namespace RenegadeWizard.Classes.Data
{
    public class DisplayDTO
    {
        public CommandResponse CommandResponse { get; set; } = null;
        public List<string> ConsoleLines { get; set; } = new();
        public List<Node> Conversations { get; set; } = new();

    }
}
