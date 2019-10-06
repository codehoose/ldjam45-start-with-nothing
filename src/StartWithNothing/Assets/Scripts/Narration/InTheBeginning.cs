using UnityEngine;

public class InTheBeginning : NarrationBehaviour
{
    public GameObject _captionText;

    public GameObject _canvas;

    public GameObject _nextStoryPoint;

    public AudioClip _thunderClap;

    public AudioSource _audioSource;

    void Awake()
    {
        Runner.Add(new WaitAction(2));
        Runner.Add(new FadeUpText(_captionText, "In the beginning there was nothing.\r\nJust darkness everywhere...", 1, 5, 1));
        Runner.Add(new FadeUpText(_captionText, "All it would take is a flash of inspiration.\r\nA spark of light!", 1, 5, 1));
        Runner.Add(new PlaySoundAction(_thunderClap, _audioSource));
        Runner.Add(new FadeCanvas(_canvas, 0.1f, 0.8f, 0.1f));
        Runner.Add(new FadeCanvas(_canvas, 0.1f, 0.5f, 0.1f));
        Runner.Add(new FadeCanvas(_canvas, 0.1f, 0.8f, 0.1f));
        Runner.Add(new FadeCanvas(_canvas, 0.1f, 0.1f, 1f));
        Runner.Add(new WaitAction(5));
        Runner.Add(new FadeCanvas(_canvas, 1, 1, 0));
        Runner.Add(new ChangeTextColourAction(_captionText, Color.black));
        Runner.Add(new FadeUpText(_captionText, "The world had formed as an infinite white plane.", 1, 5, 1));
        Runner.Add(new FadeUpText(_captionText, "No creatures or plants lived in this world.\r\nNothing grew and nothing walked its surface.", 1, 5, 1));
        Runner.Add(new WaitAction(2));
        Runner.Add(new FadeUpText(_captionText, "\r\nUntil one day...", 0.5f, 2, 3));
        Runner.Add(new ToggleActivateAction(_nextStoryPoint, true));
    }
}
