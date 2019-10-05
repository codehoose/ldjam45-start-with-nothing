using System.Collections;

public class ActivateCreatureAction : BaseAction
{
    private CreatureLocomotion _locomotion;
    private bool _enabled;

    public ActivateCreatureAction(CreatureLocomotion locomotion, bool enabled = true)
    {
        _locomotion = locomotion;
        _enabled = enabled;
    }

    public override IEnumerator Execute()
    {
        _locomotion.EnableMovement(_enabled);
        yield return null;
    }

}
