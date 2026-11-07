using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions;
using RenegadeWizardWasm.Core.Interactions.Actions;

namespace RenegadeWizardWasm.Core.Statics;

public static class ActionReg
{
    private static readonly Dictionary<string, ActionId> _aliasToId = new(StringComparer.OrdinalIgnoreCase);
    private static readonly Dictionary<ActionId, BaseAction> _idToAction = new();

    static ActionReg()
    {
        Register(new Attack());
        Register(new Fireball());
        // etc.
    }

    private static void Register(BaseAction action)
    {   
        _idToAction[action.ActionIdentity.ActionId] = action;
        foreach (var name in action.ActionIdentity.Names)
        {
            _aliasToId[name] = action.ActionIdentity.ActionId;
        }
    }

    // Used to fetch actions by ID. While players use "Aliases", we use the ID internally.
    public static BaseAction GetAction(ActionId id) => _idToAction[id];
    
    // Used for fuzzy matching if the main lookup fails.
    public static IEnumerable<string> AllAliases => _aliasToId.Keys;

    public static ActionId? FindIdByAlias(string alias) 
    {
        if (_aliasToId.TryGetValue(alias, out var id)) return id;
        return null;
    }
}