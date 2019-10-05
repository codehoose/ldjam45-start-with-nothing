using System.Collections;
using TMPro;
using UnityEngine;

public class FadeUpText : BaseAction
{
    private TextMeshProUGUI _textComponent;
    private CanvasGroup _canvasGroup;
    private string _text;
    private float _fadeIn;
    private float _holdTime;
    private float _fadeOut;

    public FadeUpText(GameObject target, string text, float fadeInTime, float holdTime, float fadeOutTime)
    {
        _text = text;
        _fadeIn = fadeInTime;
        _holdTime = holdTime;
        _fadeOut = fadeOutTime;

        _textComponent = target.GetComponent<TextMeshProUGUI>();
        _canvasGroup = target.GetComponent<CanvasGroup>();
    }

    public override IEnumerator Execute()
    {
        _canvasGroup.alpha = 0f;
        _textComponent.text = _text;
        yield return Run(_fadeIn, dt => _canvasGroup.alpha = Mathf.Lerp(0, 1, dt));
        yield return Run(_holdTime, dt => { });
        yield return Run(_fadeOut, dt => _canvasGroup.alpha = Mathf.Lerp(1, 0, dt));
    }
}
