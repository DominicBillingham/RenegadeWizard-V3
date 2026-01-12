namespace RenegadeWizardWasm.Core;



public class Terminal(InputManager inputManager, SceneManager sceneManager, CombatManager combatManager)
{

    public TerminalResponse BeginGame()
    {
        TerminalResponse terminalResponse = new();
        List<string> text =
        [
            
            "#jtrnarr W-W-W-WELCOME!",
            "#narr Welcome back all you lovely #narrrnb Warlocks and Witches!",
            "#narr After that brutal display - can anyone possibly die in a more horrific way?",
            "#narr Well we've got ourselves a new contender, straight out of failing wizard college.",
            "#narr It's the one! The only! The #jtrnarr legendary...",
            "#narr ...",
            "#narr Fuckin' crystalprompter.",
            "#narr Hey kid, not that it's gonna matter in 5 but what's yer name?",
            "",
            "#gnic Please type your name in the textbox below."
            


        ];
        terminalResponse.NarrationLines.AddRange(text);
        return terminalResponse;
    }
    
    
    
    public TerminalResponse EnterInput(string playerInput)
    {
        TerminalResponse terminalResponse = GetBaseText();
        
        inputManager.ProcessInput(playerInput);
        terminalResponse.PlayerInput  = playerInput;
        
        
        
        //terminalResponse.SceneLines.Add("This is a test of animations. #shk shake! #pls pulse! #bnc bounce! #glw glow! #flk flicker! #spn spin! #wbl wobble! #fad fade! #sld slide! #wav wave! #rnb rainbow! #grw grow! #jtr jitter! #blk blink! #flt float! #swg swing! #flp flip! #vbr vibrate! #zm zoom! #sqz squeeze! #skw skew! #els elastic! #crs cursor! #shm shimmer! #nen neon! #glt glitch! #");

        if (inputManager.chosenAction == null) 
            return terminalResponse;
        
        //terminalResponse.DebugLines.Add($"Action: {inputManager.chosenAction?.Name ?? ""} | Targets: {string.Join(", ", inputManager.Targets.Select(entity => entity.Name) ?? [])}" );
        terminalResponse.CombatLines.AddRange(combatManager.PlayRound());
        
        return terminalResponse;
    }

    public TerminalResponse GetBaseText()
    {
        TerminalResponse terminalResponse = new TerminalResponse();
        terminalResponse.Creatures = sceneManager.Npcs;
        terminalResponse.Objects = sceneManager.Objects;
        
        terminalResponse.ActionNames = sceneManager.Player.Actions.Select(action => action.Name.ToLower()).ToList();
        terminalResponse.EntityNames = sceneManager.Entities.Select(entity => entity.Name.ToLower()).ToList();
        
        terminalResponse.SceneLines.AddRange(sceneManager.GetSceneDescription());
        return terminalResponse;
    }
    
}

