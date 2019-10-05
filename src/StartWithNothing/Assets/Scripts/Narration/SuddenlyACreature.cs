using UnityEngine;

public class SuddenlyACreature : MonoBehaviour
{
    private ActionRunner _runner;

    public GameObject _captionText;

    public GameObject _cube;

    void Awake()
    {
        _runner = GetComponent<ActionRunner>();
        _runner.Add(new FadeUpText(_captionText, "\r\nSuddenly something appeared", 0.5f, 3, 1));
        _runner.Add(new LerpObjectToAction(_cube, 0.5f, new Vector3(-13, -0.91f, 0)));
        _runner.Add(new FadeUpText(_captionText, "\r\nIs that... life?", 0.1f, 3, 1));
        _runner.Add(new WaitAction(2));
        _runner.Add(new LerpObjectToAction(_cube, 0.5f, new Vector3(0, -0.91f, 0)));
        _runner.Add(new FadeUpText(_captionText, "The strange orange creature needed encouragement to move.", 0.5f, 3, 1));
        _runner.Add(new FadeUpText(_captionText, "As if some external force was pulling it left or right.", 0.5f, 4, 1));
        _runner.Add(new FadeUpText(_captionText, "\r\n...Could you be that external force?", 0.25f, 3, 1));
    }

    void Start()
    {
        _runner.Run();
    }
}
