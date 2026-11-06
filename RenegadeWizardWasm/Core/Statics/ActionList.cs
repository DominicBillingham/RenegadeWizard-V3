using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions;

namespace RenegadeWizardWasm.Core.Statics;

public static class ActionRegistry
{
    // High-performance lookup: Alias -> ActionId
    private static readonly Dictionary<string, ActionId> _aliasToId = new(StringComparer.OrdinalIgnoreCase);
    
    // Quick lookup: ActionId -> Action Instance
    private static readonly Dictionary<ActionId, BaseAction> _actions = new();

    static ActionRegistry()
    {
        Register(new Attack());
        Register(new Fireball());
        // etc.
    }

    private static void Register(BaseAction action)
    {   
        _actions[action.ActionIdentity.ActionId] = action;
        foreach (var name in action.ActionIdentity.Names)
        {
            _aliasToId[name] = action.ActionIdentity.ActionId;
        }
    }

    public static BaseAction GetAction(ActionId id) => _actions[id];
    
    public static IEnumerable<string> AllAliases => _aliasToId.Keys;

    public static ActionId? FindIdByAlias(string alias) 
    {
        if (_aliasToId.TryGetValue(alias, out var id)) return id;
        return null;
    }
}