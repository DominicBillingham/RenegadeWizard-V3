using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Services;

public class SceneManager
{
    public List<Entity> Entities;
    public Entity GetPlayer => Entities.First(x => x.IsPlayer);
}