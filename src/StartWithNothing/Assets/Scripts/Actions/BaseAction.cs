using System;
using System.Collections;
using UnityEngine;

public abstract class BaseAction : IAction
{
    private ActionRunner _runner;

    public abstract IEnumerator Execute();

    protected IEnumerator Run(float duration, Action<float> action)
    {
        float time = 0; 
        while (time < 1f)
        {
            action(time);
            time += Time.deltaTime / duration;
            yield return null;
        }

        action(1f);
    }
}
