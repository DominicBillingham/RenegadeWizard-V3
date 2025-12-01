using RenegadeWizard.Classes.Utility;

namespace RenegadeWizard.Classes.Data
{
    public class Compendium
    {
        public List<Entity> Entities { get; set; } = new();
        public Compendium() {

            Entities.Add(new Entity(
                "HandGrenade",
                "Pull the pin, throw, and then run!",
                destruction: 3
            ));

            Entities.Add(new Entity(
                "FryingPan",
                "You don't really know how to use this for cooking, but it's sure great for whacking!",
                destruction: 2
            ));

            Entities.Add(new Entity(
                "Shotgun",
                "All pellets are enchanted to vanish after 10ft, as per firearm regulation 206.",
                destruction: 5
            ));

            Entities.Add(new Entity(
                "Rations",
                "'Rations' is a rather generous way to describe some mouldy bread.",
                taste: 3
            ));

            Entities.Add(new Entity(
                "Rock",
                "You've collected one, now collect the other 2034! [ROCK COLLECTOR ACHIEVEMENT]",
                destruction: 1
            ));


        }

        public Entity? FindEntity(string[] input)
        {
            foreach (var ent in Entities)
            {
                if (InputHelper.FuzzyMatch(ent.Name, input))
                {
                    return ent;
                }
            }

            return null;

        }

        public List<string> CheckInventory()
        {
            List<string> inventory = new();

            foreach (var ent in Entities)
            {
                inventory.Add(MML.Html($"# {ent.Name} - {ent.Description} "));
            }

            return inventory;

        }

    }
}
