using System.Collections;
using UnityEngine;

public class FadeCanvas : BaseAction
{
    private CanvasGroup _canvasGroup;
    private float _duration;
    private float _from;
    private float _to;

    public FadeCanvas(GameObject target, float duration, float from, float to)
    {
        _canvasGroup = target.GetComponent<CanvasGroup>();
        _duration = duration;
        _from = from;
        _to = to;
    }

    public override IEnumerator Execute()
    {
        yield return Run(_duration, dt => _canvasGroup.alpha = Mathf.Lerp(_from, _to, dt));
    }
}
