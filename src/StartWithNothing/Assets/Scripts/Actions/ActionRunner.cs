using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRunner : MonoBehaviour
{
    private readonly Queue<IAction> _actions = new Queue<IAction>();
    private bool _executing = false;
    private bool _started = false;
    private IAction _current = null;

    public void Add(IAction action)
    {
        _actions.Enqueue(action);
    }

    public void Run()
    {
        if (_started)
        {
            return;
        }

        _started = true;
        StartCoroutine(ShootTheRunner()); // Homage to Kasabian ;)
    }

    IEnumerator ShootTheRunner()
    {
        if (_actions.Count == 0)
        {
            yield break;
        }

        do
        {
            var action = _actions.Dequeue();
            yield return action.Execute();

        } while (_actions.Count > 0);
    }
}
