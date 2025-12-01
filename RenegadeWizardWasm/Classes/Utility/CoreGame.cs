using RenegadeWizard.Classes.Data;
using RenegadeWizard.Classes.Nodes;
using RenegadeWizard.Classes.Utility;
using RenegadeWizard.Classes.Enums;
using System.Linq.Expressions;

namespace RenegadeWizard.Classes
{
    public class CoreGame
    {
        private readonly NodeHandler _nodeHandler;
        private readonly Compendium _compendium;
        private Entity _player;

        public CoreGame()
        {
            _nodeHandler = new NodeHandler();
            _compendium = new Compendium();

            _player = new Entity("Player", "Notharry");
            _player.Reflexes = 5;
            _player.Insight = 5;
            _player.Determination = 5;
        }

        public CommandResponse GetResponse(string input)
        {

            string[] inputArray = InputHelper.ProcessInput(input);
            var response = CheckCommands(inputArray);

            if (response is null)
            {
                if (InputHelper.FuzzyMatch(["Go", "Speak", "Talk,", "Travel"], inputArray))
                {
                    response = _nodeHandler.SwapNode(inputArray);
                }
                else if (_nodeHandler.CurrentNode is not null)
                {
                    response = _nodeHandler.CheckNodeKeywords(inputArray);
                    Entity? item = _compendium.FindEntity(inputArray);

                    response = ResolveItemCheck(response, item);
                    response = ResolveSkillCheck(response, item);
                }
                else
                {
                    response = new CommandResponse();
                    response.TextStrings.Add(MML.Html("# DEV: Something has gone wrong! If you've ended up here, I've broken something..."));
                }
            }

            response.FormatStrings.Add("");
            response.FormatStrings.Add(new HtmlBuilder().Text($"> {input}").Build());
            return response;

        }

        public CommandResponse? CheckCommands(string[] input)
        {
            if (InputHelper.FuzzyMatch("Help", input))
            {
                CommandResponse response = new();
                response.TextStrings.Add(MML.Html("#blu Renegade Wizard is a first person, text-based, adventure game. To interact with the world, simply type a sentence like: ‘I look through the #ylw telescope#blu ' or 'I #grn swim #blu in the pond'."));
                response.TextStrings.Add(string.Empty);
                response.TextStrings.Add(MML.Html("#blu Keywords allow you to interact with the world. These are words that are yellow or green."));
                response.TextStrings.Add(MML.Html("#blu Keywords in #noun yellow #blu will give further information."));
                response.TextStrings.Add(MML.Html("#blu Keywords in #verb green #blu will progress the story."));
                response.TextStrings.Add(MML.Html("#blu Keywords in #item orange #blu are items."));

                response.TextStrings.Add(string.Empty);
                response.TextStrings.Add(MML.Html("#blu Capitalisation doesn’t matter, and you can make minor spelling mistakes."));
                return response;
            }

            if (InputHelper.FuzzyMatch(["Inventory", "Inv"], input))
            {
                CommandResponse response = new();
                response.TextStrings = _compendium.CheckInventory();
                return response;
            }

            return null;

        }

        public CommandResponse ResolveItemCheck(CommandResponse response, Entity? item)
        {
            if (response.ItemCheckFail == null)
            {
                return response;
            }

            if (item == null)
            {
                response = new();
                response.TextStrings.Add(MML.Html("# This item wasn't found!"));
                return response;
            }


            int itemBonus = 0;
            itemBonus = response.ItemCheckProperty switch
            {
                Property.Weight => item.Weight,
                Property.Volume => item.Volume,
                Property.Smell => item.Smell,
                Property.Brightness => item.Brightness,
                Property.Taste => item.Taste,
                Property.Softness => item.Softness,
                Property.Loudness => item.Loudness,
                Property.Destruction => item.Destruction,
                Property.Stickiness => item.Stickiness,
                _ => 0
            };

            if (itemBonus < response.ItemCheckDifficulty)
            {
                return response.ItemCheckFail;
            }

            return response;

        }


        public CommandResponse ResolveSkillCheck(CommandResponse response, Entity? item = null)
        {
            if (response.SkillCheckFail is null)
            {
                return response; 
            }

            string skillStr = string.Empty;

            int dice1 = Dice.Roll(1, 6);
            int dice2 = Dice.Roll(1, 6);

            int stat = response.SkillCheckAttribute switch
            {
                Skill.Determination => _player.Determination,
                Skill.Reflexes => _player.Reflexes,
                Skill.Insight => _player.Insight,
                _ => 0
            };

            int itemBonus = 0;
            if (item != null)
            {
                itemBonus = response.SkillCheckProperty switch
                {
                    Property.Weight => item.Weight,
                    Property.Volume => item.Volume,
                    Property.Smell => item.Smell,
                    Property.Brightness => item.Brightness,
                    Property.Taste => item.Taste,
                    Property.Softness => item.Softness,
                    Property.Loudness => item.Loudness,
                    Property.Destruction => item.Destruction,
                    Property.Stickiness => item.Stickiness,
                    _ => 0
                };

                response.ActionStrings[response.ActionStrings.Count-1] += " " + item.UseText;
            }

            if (response.SkillCheckDifficulty > stat + dice1 + dice2 + itemBonus)
            {
                skillStr = MML.Html($"#blu Failure: {dice1 + dice2} ({dice1}+{dice2}) + {stat} ({response.SkillCheckAttribute.ToString()}) + {itemBonus} (Item)");
                response.SkillCheckFail.SkillStrings.Add(skillStr);
                response.SkillCheckFail.ActionStrings = response.ActionStrings;
                return response.SkillCheckFail;
            }
            else
            {
                skillStr = MML.Html($"#blu Success: {dice1 + dice2} ({dice1}+{dice2}) + {stat} ({response.SkillCheckAttribute.ToString()}) + {itemBonus} (Item)");
                response.SkillStrings.Add(skillStr);
                return response; 
            }

        }


    }
}
