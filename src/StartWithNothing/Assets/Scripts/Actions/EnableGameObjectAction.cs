using System.Collections;
using UnityEngine;

public class EnableGameObjectAction : BaseAction
{
    private GameObject _target;
    private bool _enabled;

    public EnableGameObjectAction(GameObject target, bool enabled)
    {
        _target = target;
        _enabled = enabled;
    }

    public override IEnumerator Execute()
    {
        _target.SetActive(_enabled);
        yield return null;
    }

}
