using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.Interactions;

namespace RenegadeWizardWasm.Core.UserInterface;



public class Terminal(InputManager inputManager, SceneManager sceneManager, CombatManager combatManager)
{
    
    public TerminalResponse BeginGame()
    {        
        TerminalResponse terminalResponse = new();

        //terminalResponse.NarrationLines.Add("This is a test of animations. #shk shake! #pls pulse! #bnc bounce! #glw glow! #flk flicker! #spn spin! #wbl wobble! #fad fade! #sld slide! #wav wave! #rnb rainbow! #grw grow! #jtr jitter! #blk blink! #flt float! #swg swing! #flp flip! #vbr vibrate! #zm zoom! #sqz squeeze! #skw skew! #els elastic! #crs cursor! #shm shimmer! #nen neon! #glt glitch! #");
        
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
        terminalResponse.NarrationLines.AddRange(text);
        return terminalResponse;
    }

    public TerminalResponse EnterName(string playerInput) {
        
        TerminalResponse terminalResponse = new();
        
        inputManager.ProcessInput(playerInput);
        terminalResponse.PlayerInput  = playerInput;
        
        sceneManager.Player.Name = playerInput;
        
        List<string> text =
        [
            $"#narr Well, it's fucking awful to meet ya {playerInput}",
            "#narr Hope you like ya name, you'll be hearin' it a fuck ton. ",
            $"#narr Well {playerInput}... you know the rules and so do I. IT'S TIME FOR- ",
            "#narrnenbg RENEGADE WIZZZZZZZZZAAAAARRRRRRRRDDDDD #pls ▼",
            "",
            "",
            ""
        ];
        
        terminalResponse.NarrationLines.AddRange(text);
        
        List<string> text2 =
        [
            $"#narr {playerInput} stands at the wizard tower's base.",
            "#narr A flimsy, weak, old and pathetic wooden door prevents access!",
            "#narr How will our contestant ever fare?",
            "#gnic Type any action, along with a target, such as 'I [punch] the [door]",
        ];

        terminalResponse.NarrationLines.AddRange(text2);

        return terminalResponse;
        
    }
    
    
    public TerminalResponse EnterInput(string playerInput)
    {
        TerminalResponse terminalResponse = new ();
        
        inputManager.ProcessInput(playerInput);
        terminalResponse.PlayerInput  = playerInput;

        if (inputManager.chosenAction == null)
        {
            PopulateTerminal(terminalResponse);
            return terminalResponse;
        }
        
        terminalResponse.DebugLines.Add($"Action: {inputManager.chosenAction?.Name ?? ""} | Targets: {string.Join(", ", inputManager.Targets.Select(entity => entity.Name) ?? [])}" );
        
        terminalResponse.CombatLines.AddRange(combatManager.PlayRound());
        
        PopulateTerminal(terminalResponse);
        
        return terminalResponse;
    }

    public void PopulateTerminal(TerminalResponse terminalResponse)
    {
        terminalResponse.ActionCards = sceneManager.Player.Actions.Select(action => new TerminalCard(action)).ToList();
        terminalResponse.CreatureCards = sceneManager.Npcs.Select(entity => new TerminalCard(entity)).ToList();
        terminalResponse.ObjectCards = sceneManager.Objects.Select(entity => new TerminalCard(entity)).ToList();
        
        terminalResponse.ActionNames = sceneManager.Player.Actions.Select(action => action.Name.ToLower()).ToList();
        terminalResponse.EntityNames = sceneManager.Entities.Select(entity => entity.Name.ToLower()).ToList();
    }
    
}

