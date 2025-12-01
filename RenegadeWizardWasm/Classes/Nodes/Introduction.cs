using RenegadeWizard.Classes.Data;
using RenegadeWizard.Classes.Nodes;
using RenegadeWizard.Classes.Utility;
using RenegadeWizard.Classes.Enums;
using static System.Net.WebRequestMethods;


public class Opening : Node {

    public override CommandResponse Auto()
    {
        CommandResponse response = new();
        return response;
    }

    public override CommandResponse Fallback()
    {
        CommandResponse response = new();

        response.TextStrings.Add(MML.Html("# To #verb start # your adventure, simply type #verb start. # Type #info help # for more guidance."));

        return response;
    }

    public Opening()
    {
        Names = new List<string> { "Opening" };

        Keywords.Add(new KeyWords(new[] { "Start" },
            () =>
            {
                CommandResponse response = new();

                response.TextStrings.Add(MML.Html("# Restless, you can’t find any solace in sleep. Your mind races with dreams of the future, when you are finally granted that single, sole wish. Each thought brings another incredible possibility to consider."));
                response.TextStrings.Add(MML.Html("# But with an entire Mountain to climb, and the stars to reach - you'll have plenty of time to decide. Just the thought of such a trial makes you hungry..."));
                response.TextStrings.Add(MML.Html("# Stomach rumbling, you #verb reach # for your ration pouch."));
                response.TextStrings.Add(MML.Html("#info Type a #verb green word #info in your sentence to progress the story. For example, 'I #verb reach #info for the pouch.'"));

                response.Audio = "sound/birds2.mp3";
                response.OverrideAudio = true;

                return response;
            }
        ));

        Keywords.Add(new KeyWords(new[] { "Reach" },
            () =>
            {
                CommandResponse response = new();

                response.TextStrings.Add(MML.Html("# It’s gone! Your eyes scan for the thief, only to find two black beady eyes of looking dead back at you."));
                response.TextStrings.Add(MML.Html("# The goose stands there for a second, as if taking pleasure in seeing your anguished look before it scurries away. After taking a moment to process the sheer audacity of the beast, you begin to #verb sprint # after it."));

                return response;
            }
        ));

        Keywords.Add(new KeyWords(new[] { "Sprint", "Run" },
            () =>
            {
                CommandResponse response = new();

                response.TextStrings.Add(MML.Html("# You rush through the brambles. You're about to close the distance, when a magical whirlwind of leaves and shrubbery engulfs both you and the goose. You stumble through the green chaos only to find a sly fox where the goose should of been, your rations trapped between it's teeth. It looks at you for a split-second, before bolting."));
                response.TextStrings.Add(MML.Html("# The delicate words of #mono 'fucking brilliant' # cross your mind you wonder how to stop the shapeshifting critter. Try to #verb block # it's escape, or #verb lunge # after the beast."));

                return response;
            }
        ));

        Keywords.Add(new KeyWords(new[] { "Block" },
            () =>
            {
                CommandResponse response = new();

                response.SkillCheckFail = new();
                response.SkillCheckAttribute = Skill.Insight;
                response.SkillCheckDifficulty = 0;

                response.TextStrings.Add(MML.Html("# The doppelganger find it's escape route intercepted by you, panicking, it scurries up a tree. Somewhat safe in the branches, the shapeshifter's form beings to change once more..."));
                response.TextStrings.Add(MML.Html("# Left behind is now a rather pitiful looking, tiny #noun mossdragon# . Their eyes now fill with wide and guilty pupils, before dropping the pouch for you to #verb catch# ."));
                response.TextStrings.Add(MML.Html("#info Type a #noun yellow word #info in your sentence to learn information. For example, 'What's a #noun mossdragon#info '."));

                return response;
            }
        ));

        Keywords.Add(new KeyWords(new[] { "Lunge" },
            () =>
            {
                CommandResponse response = new();

                response.SkillCheckFail = new();
                response.SkillCheckAttribute = Skill.Reflexes;
                response.SkillCheckDifficulty = 0;

                response.TextStrings.Add(MML.Html("# The doppelganger scurries up a tree to avoid your lunge, only to find itself trapped. Somewhat safe in the branches, the shapeshifter's form beings to change once more..."));
                response.TextStrings.Add(MML.Html("# Left behind is now a rather pitiful looking, tiny #noun mossdragon# . Their eyes now fill with wide and guilty pupils, before dropping the pouch for you to #verb catch# ."));
                response.TextStrings.Add(MML.Html("#info Type a #noun yellow word #info in your sentence to learn information. For example, 'What's a #noun mossdragon#info '."));

                return response;
            }
        ));

        Keywords.Add(new KeyWords(new[] { "Mossdragon" },
            () =>
            {
                CommandResponse response = new();

                response.SkillCheckFail = new();
                response.SkillCheckAttribute = Skill.Insight;
                response.SkillCheckDifficulty = 0;

                response.TextStrings.Add(MML.Html("# You've heard about these creatures, they are both small in stature and magic, but they can heal wounds, shapeshift and sense sorrow. The fairytales say that these little terrors always find their way to those who have suffered loss... "));

                return response;
            }
        ));

        Keywords.Add(new KeyWords(new[] { "Catch" },
            () =>
            {
                CommandResponse response = new();

                response.TextStrings.Add(MML.Html("# For once, you're able to actually catch something, as pouch falls into you grasp. The mossdragon moves above. It slinks between the branches, with it’s long tail flowing behind it’s thin body. The mossdragon’s eyes dart between you and the food…"));
                response.TextStrings.Add(MML.Html("# You could #verb throw # some #item rations # towards the fellow, or a #item rock # out of vengence. "));
                response.TextStrings.Add(MML.Html("#info Type both a #verb green word #info and an #item item #info to use an item. For example, 'i #verb throw #info the #item rations#info .'"));

                return response;
            }
        ));


        Keywords.Add(new KeyWords(new[] { "Throw" },
            () =>
            {
                CommandResponse response = new();

                response.TextStrings.Add(MML.Html("# With a swift, agile motion it's jaws snatch the bread before it even lands. Too large to be eaten whole the dragon voraciously rips it apart chunk by chunk. After it's eaten the lot, it let's out a happy #f7 *chiiiiirrrrp* # and then freezes still. It tilts it's head towards you, as it stares deep into your eyes."));
                response.TextStrings.Add(MML.Html("# A few long seconds later, it leaps from the tree, before darting between piles of leaves and into the horizon. You get the feeling it'll find you again."));
                response.TextStrings.Add(MML.Html("# ..."));
                response.TextStrings.Add(MML.Html("# With your rations back in your possession, you catch your breath and #verb look # around."));


                response.ItemCheckFail = new();
                response.ItemCheckDifficulty = 2;
                response.ItemCheckProperty = Property.Taste;

                response.ItemCheckFail.TextStrings.Add(MML.Html("# The mossdragon leaps from the tree avoiding the projectile, before darting between piles of leaves and into the horizon. It's learnt it's lesson, for now."));
                response.ItemCheckFail.TextStrings.Add(MML.Html("# ..."));
                response.ItemCheckFail.TextStrings.Add(MML.Html("# With your rations back in your possession, you catch your breath and #verb look # around."));

                return response;
            }
        ));


        Keywords.Add(new KeyWords(new[] { "Look" },
            () =>
            {
                CommandResponse response = new();

                response.TextStrings.Add(MML.Html("# The rather aptly named Soggy Hills sprawl out behind you, an unmoving sea of verdant waves. As for what lies ahead, it is none other than Mount Endeavour, a mountain that pierces the clouds and stretches towards the stars. A few days ago it dominated the horizon, and now it dominates the sky itself as you stand beneath it. "));
                response.TextStrings.Add(MML.Html("# A pilgrim's standing stone marks the first of many winding paths carved the rock's surface, the #noun words # of Justice enscribed on slate for all to see. Beyond the stone, you can see various #noun landmarks # dotting the valley."));

                return response;
            }
        ));


        Keywords.Add(new KeyWords(new[] { "Landmarks" },
            () =>
            {
                CommandResponse response = new();

                response.TextStrings.Add(MML.Html("# To your East, lies the Slumbering #node Woods#, flanking the great river Eight that flows down Mount Endeavour's surface. The soft melodies of songbirds ring out from the trees. "));
                response.TextStrings.Add(MML.Html("# To your West, titantic flowers erupt from the ground to form a canopy of vibrant umbrellas. The Titan's #node Meadow# , a beautiful place born of tragedy."));
                response.TextStrings.Add(MML.Html("# Finally, past the standing stone is the ancient #node tower# , a colossal bridge joins the spire's top to the Mountain. It's walls are devoid of detail, the tower's history forever unknown."));
                response.TextStrings.Add(MML.Html("#info You can type a #node pink word #info alongside the word 'go' to travel there. For exmaple 'I go to the #node Meadow#info '."));

                return response;
            }
        ));


    }

}



//}


//CommandResponse response = new();

//response.TextStrings.Add(MML.Html("#just You, desperate seeker, have arrived at this mountain like so many hopefuls before you. You hope to find salvation in the form a lonesome wish."));

//response.TextStrings.Add(MML.Html("#just However, seeker, such gifts are not given freely and must be earned. Follow my footsteps and ascend to the greatest height this world offers."));

//response.TextStrings.Add(MML.Html("#just Let it be foretold that you will suffer, that failure is friend to nearly every mortal arrogant enough to attempt the climb."));

//response.TextStrings.Add(MML.Html("#just So seeker, how arrogant are you?"));

//response.TextStrings.Add(MML.Html("# ..."));

//response.TextStrings.Add(MML.Html("#mono Well this 'Justice' seems like an absolute joy."));




//return response;
    


