namespace RenegadeWizardWasm.Core.UserInterface;

public class RoundResult
{
    // This is a single object that gathers all the results of a single round.
    // It will then return this information to the user interface..

    public string rawUserInput { get; set; }

    // Will format the text ready for the console.
    public string text => rawUserInput + "fish";

    // What the user entered
    // What action was selected
    // What targets were select

    // Actions, grouped together 1 by 1 so we can do a play by play.
    // PlayerAction
    // NPCAction

    // Character sheet page
    // -> Stress, Vigour, Hunger
    // -> Current items
    // -> Current tags

    // Map page
    // -> Where the player is
    // -> What times are around


}