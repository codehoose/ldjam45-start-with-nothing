using UnityEngine;

public class SuddenlyACreature : NarrationBehaviour
{
    public GameObject _captionText;

    public GameObject _canvasGroup;

    public GameObject _cube;

    public CreatureLocomotion _locomotion;

    public GameObject[] _blocks;

    void Awake()
    {
        foreach (var block in _blocks)
        {
            Runner.Add(new EnableGameObjectAction(block, false));
        }
        Runner.Add(new FadeCanvas(_canvasGroup, 0f, 0f, 0f));
        Runner.Add(new ChangeTextColourAction(_captionText, Color.black));
        Runner.Add(new FadeUpText(_captionText, "\r\nSuddenly something appeared...", 0.5f, 3, 1));
        Runner.Add(new LerpObjectToAction(_cube, 0.5f, new Vector3(-13, -0.91f, 0)));
        Runner.Add(new FadeUpText(_captionText, "\r\nIs that... life?", 0.1f, 3, 1));
        Runner.Add(new WaitAction(2));
        Runner.Add(new LerpObjectToAction(_cube, 0.5f, new Vector3(0, -0.91f, 0)));
        Runner.Add(new FadeUpText(_captionText, "The strange creature needed encouragement to move.", 0.5f, 3, 1));
        Runner.Add(new FadeUpText(_captionText, "As if some external force was pulling it left or right.", 0.5f, 4, 1));
        Runner.Add(new FadeUpText(_captionText, "\r\n...Could you be that external force?", 0.25f, 3, 1));
        Runner.Add(new ActivateCreatureAction(_locomotion, true));
        foreach (var block in _blocks)
        {
            Runner.Add(new EnableGameObjectAction(block, true));
        }
    }
}
