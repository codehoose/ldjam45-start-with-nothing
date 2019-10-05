using System.Collections;
using UnityEngine;

public class LerpObjectToAction : BaseAction
{
    private GameObject _gameObject;
    private Vector3 _target;
    private float _duration;
    private Vector3 _start;

    public LerpObjectToAction(GameObject gameObject, float duration, Vector3 target)
    {
        _gameObject = gameObject;
        _target = target;
        _duration = duration;
    }


    public override IEnumerator Execute()
    {
        _start = _gameObject.transform.position;
        yield return Run(_duration, dt => _gameObject.transform.position = Vector3.Lerp(_start, _target, dt));       
    }
}
