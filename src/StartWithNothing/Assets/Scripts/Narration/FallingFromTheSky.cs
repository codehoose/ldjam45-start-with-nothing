using UnityEngine;

public class FallingFromTheSky : NarrationBehaviour
{
    public GameObject _captionText;
    public GameObject _strangeObjectSpawner;

    void Awake()
    {
        Runner.Add(new ChangeTextColourAction(_captionText, Color.white));
        Runner.Add(new FadeUpText(_captionText, "\r\nColour has brought danger with it!", 0.5f, 3, 1));
        Runner.Add(new FadeUpText("\r\nFrom the sky strange objects appear!", _captionText, 0.5f, 0, 1));
        Runner.Add(new ToggleActivateAction(_strangeObjectSpawner, true));
        Runner.Add(new PerformAction(() =>
        {
            var spawner = _strangeObjectSpawner.GetComponent<StrangeObjectSpawner>();
            spawner.EnableDrop(true);
        }));
        Runner.Add(new WaitAction(5));
        Runner.Add(new FadeUpText("\r\nFrom the sky strange objects appear!", _captionText, 0.5f, 1, 0));
        Runner.Add(new FadeUpText(_captionText, "\r\nWatch out!!", 0.5f, 1, 1));
        Runner.Add(new FadeUpText(_captionText, "\r\nThose things look dangerous!", 0.5f, 1, 1));
        Runner.Add(new WaitAction(5));
        Runner.Add(new ToggleActivateAction(_strangeObjectSpawner, false));
        Runner.Add(new PerformAction(() =>
        {
            var spawner = _strangeObjectSpawner.GetComponent<StrangeObjectSpawner>();
            spawner.EnableDrop(false);
        }));
        Runner.Add(new FadeUpText(_captionText, "\r\nThe storm subsides and peace is restored.", 0.5f, 1, 1));
    }
}
