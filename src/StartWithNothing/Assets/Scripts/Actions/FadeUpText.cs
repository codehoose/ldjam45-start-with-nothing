using System.Collections;
using TMPro;
using UnityEngine;

public class FadeUpText : BaseAction
{
    private float _to;
    private TextMeshProUGUI _textComponent;
    private CanvasGroup _canvasGroup;
    private string _text;
    private float _fadeIn;
    private float _holdTime;
    private float _fadeOut;
    private float _from;

    public FadeUpText(GameObject target, string text, float fadeInTime, float holdTime, float fadeOutTime)
    {
        _text = text;
        _fadeIn = fadeInTime;
        _holdTime = holdTime;
        _fadeOut = fadeOutTime;

        _from = 0f;
        _to = 1f;

        _textComponent = target.GetComponent<TextMeshProUGUI>();
        _canvasGroup = target.GetComponent<CanvasGroup>();
    }

    public FadeUpText(string text, GameObject target, float fadeInTime, float from, float to)
    {
        _text = text;
        _fadeIn = fadeInTime;
        _holdTime = -1;

        _from = 0f;
        _to = 1f;

        _textComponent = target.GetComponent<TextMeshProUGUI>();
        _canvasGroup = target.GetComponent<CanvasGroup>();
    }

    public override IEnumerator Execute()
    {
        _canvasGroup.alpha = 0f;
        _textComponent.text = _text;
        yield return Run(_fadeIn, dt => _canvasGroup.alpha = Mathf.Lerp(_from, _to, dt));
        if (_holdTime >= 0)
        {
            yield return Run(_holdTime, dt => { });
            yield return Run(_fadeOut, dt => _canvasGroup.alpha = Mathf.Lerp(_to, _from, dt));
        }
    }
}
