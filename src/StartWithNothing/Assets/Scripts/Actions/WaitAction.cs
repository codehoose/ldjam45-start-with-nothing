using System.Collections;
using UnityEngine;

public class WaitAction : BaseAction
{
    private float _duration;

    public WaitAction(float duration)
    {
        _duration = duration;
    }

    public override IEnumerator Execute()
    {
        yield return new WaitForSeconds(_duration);
    }
}
