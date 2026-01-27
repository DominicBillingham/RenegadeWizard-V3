
namespace RenegadeWizardWasm.Core.UserInterface;

public static class StaticResponses
{
    
    public static void BeginGame(GameResponse response)
    {        
        //response.NarrationLines.Add("This is a test of animations. #shk shake! #pls pulse! #bnc bounce! #glw glow! #flk flicker! #spn spin! #wbl wobble! #fad fade! #sld slide! #wav wave! #rnb rainbow! #grw grow! #jtr jitter! #blk blink! #flt float! #swg swing! #flp flip! #vbr vibrate! #zm zoom! #sqz squeeze! #skw skew! #els elastic! #crs cursor! #shm shimmer! #nen neon! #glt glitch! #");
        
        List<string> text =
        [
            "#jtrnarr W-W-W-WELCOME!",
            "#narr Welcome back all you lovely #narrrnb Warlocks and Witches!",
            "#narr After that brutal display - can anyone possibly die in a more horrific way?",
            "#narr Well we've got ourselves a new contender, straight out of failing wizard college.",
            "#narr It's the one! The only! The #jtrnarr legendary- #pls ▼ # [press enter] ",
            "#narr ... #pls ▼",
            "#narr Fuckin' crystalprompter.",
            "#narr Hey kid, not that it's gonna matter in 5 but what's ya name?",
            "#gnic Please type your name in the textbox below."
        ];
        response.NarrationLines.AddRange(text);
    }

    public static void EnterName(GameResponse response, string name) {
        
        List<string> text =
        [
            $"#narr Well, it's fucking awful to meet ya {name}",
            "#narr Hope you like ya name, you'll be hearin' it a fuck ton. ",
            $"#narr Well {name}... you know the rules and so do I. IT'S TIME FOR- ",
            "#narrnenbg RENEGADE WIZZZZZZZZZAAAAARRRRRRRRDDDDD #pls ▼",
            "",
            "",
            ""
        ];
        
        response.NarrationLines.AddRange(text);
        
        List<string> text2 =
        [
            $"#narr {name} stands at the wizard tower's base.",
            "#narr A flimsy, weak, old and pathetic wooden door prevents access!",
            "#narr How will our contestant ever fare?",
            "#gnic Type any action, along with a target, such as 'I [punch] the [door]",
        ];

        response.NarrationLines.AddRange(text2);
        
    }
}

