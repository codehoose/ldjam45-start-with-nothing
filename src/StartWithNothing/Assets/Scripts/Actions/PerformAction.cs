using System;
using System.Collections;

public class PerformAction : BaseAction
{
    private Action _action;

    public PerformAction(Action action)
    {
        _action = action;
    }

    public override IEnumerator Execute()
    {
        _action();
        yield return null;
    }
}
