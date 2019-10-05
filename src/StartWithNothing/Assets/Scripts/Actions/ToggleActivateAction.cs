using System.Collections;
using UnityEngine;

public class ToggleActivateAction : BaseAction
{
    private GameObject _target;
    private bool _active;

    public ToggleActivateAction(GameObject target, bool active)
    {
        _target = target;
        _active = active;
    }

    public override IEnumerator Execute()
    {
        _target.SetActive(_active);
        yield return null;
    }
}
