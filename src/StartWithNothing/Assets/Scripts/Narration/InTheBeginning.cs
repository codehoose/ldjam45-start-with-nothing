using UnityEngine;

public class InTheBeginning : MonoBehaviour
{
    private ActionRunner _actionRunner;

    public GameObject _captionText;

    public GameObject _canvas;

    public GameObject _nextStoryPoint;

    void Awake()
    {
        _actionRunner = GetComponent<ActionRunner>();
        _actionRunner.Add(new FadeUpText(_captionText, "In the beginning there was nothing.\r\nJust darkness everywhere...", 1, 5, 1));
        _actionRunner.Add(new FadeUpText(_captionText, "All it would take is a flash of inspiration.\r\nA spark of light!", 1, 5, 1));
        _actionRunner.Add(new FadeCanvas(_canvas, 0.1f, 0.8f, 0.1f));
        _actionRunner.Add(new FadeCanvas(_canvas, 0.1f, 0.5f, 0.1f));
        _actionRunner.Add(new FadeCanvas(_canvas, 0.1f, 0.8f, 0.1f));
        _actionRunner.Add(new FadeCanvas(_canvas, 0.1f, 0.1f, 1f));
        _actionRunner.Add(new WaitAction(5));
        _actionRunner.Add(new FadeCanvas(_canvas, 1, 1, 0));
        _actionRunner.Add(new FadeUpText(_captionText, "The land was good and green and the sky was blue.\r\nBut the world was lifeless.", 1, 5, 1));
        _actionRunner.Add(new FadeUpText(_captionText, "No creatures or plants lived in this world.\r\nNothing grew and no one walked its surface.", 1, 5, 1));
        _actionRunner.Add(new WaitAction(2));
        _actionRunner.Add(new FadeUpText(_captionText, "\r\nUntil one day...", 0.5f, 2, 3));
        _actionRunner.Add(new ToggleActivateAction(_nextStoryPoint, true));
    }

    void Start()
    {
        _actionRunner.Run();
    }
}
