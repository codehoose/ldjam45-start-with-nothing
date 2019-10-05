using System.Collections;
using TMPro;
using UnityEngine;

public class ChangeTextColourAction : BaseAction
{
    private GameObject _target;
    private Color _color;
    private float _fadeTime;

    public ChangeTextColourAction(GameObject target, Color color, float fadeTime = 0f)
    {
        _target = target;
        _color = color;
        _fadeTime = fadeTime;
    }

    public override IEnumerator Execute()
    {
        var text = _target.GetComponent<TextMeshProUGUI>();

        if (_fadeTime <= 0)
        {
            text.color = _color;
            yield return null;
        }
        else
        {
            var color = text.color;
            yield return Run(_fadeTime, dt => Color.Lerp(color, _color, dt));
        }
    }

}
