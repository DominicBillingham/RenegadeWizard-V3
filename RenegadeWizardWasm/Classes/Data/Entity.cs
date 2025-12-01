using RenegadeWizard.Classes.Nodes;

namespace RenegadeWizard.Classes
{
    public class Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Node Conversation { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public int Determination { get; set; }
        public int Reflexes { get; set; }
        public int Insight { get; set; }




        public Entity(string name, string description, int weight = 0, int volume = 0, int smell = 0, int brightness = 0, int taste = 0, int softness = 0, int loudness = 0, int destruction = 0, int durability = 0, int distraction = 0) 
        {
            Name = name;
            Description = description;
            Weight = weight;
            Volume = volume;
            Smell = smell;
            Brightness = brightness;
            Taste = taste;
            Softness = softness;
            Loudness = loudness;
            Destruction = destruction;
            Durability = durability;
            Distraction = distraction;

        }


        // These are item values. All item vermine alues are between 0 and 5.
        // These are the values that detwhat an item does when used.


        // Physcial Properties
        public int Weight { get; set; } = 0;
        public int Volume { get; set; } = 0;

        // Senses
        public int Smell { get; set; } = 0;
        public int Brightness { get; set; } = 0;
        public int Taste { get; set; } = 0;
        public int Softness { get; set; } = 0;
        public int Loudness { get; set; } = 0;

        // Tool Usage
        public int Destruction { get; set; } = 0;
        public int Stickiness { get; set; } = 0;
        public int Durability { get; set; } = 0;
        public int Distraction { get; set; } = 0;
        public int Mobility { get; set; } = 0;
        public string UseText { get; set; } = string.Empty;

    }


}
