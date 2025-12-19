namespace RenegadeWizardWasm.Core;

public class ActionResolver(SceneManager sceneManager)
{
    public List<string> ResolveAction(GameAction action)
    {

        List<string> actionLines = new List<string>();

        foreach (Entity target in action.Targets)
        {
            if (action.Damage is { } damage)
            {
                target.Hitpoints -= damage;
                actionLines.Add($"{target.Name} took {damage} damage from {action.Actor.Name}.");
            }

            if (action.Heal is { } heal)
            {
                target.Hitpoints += heal;
                actionLines.Add($"{target.Name} healed {heal} hitpoints from {action.Actor.Name}.");
            }
        }

        return actionLines;
    }
}