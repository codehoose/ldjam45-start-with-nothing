using UnityEngine;

public class Elightenment : NarrationBehaviour // Spelling mistake :(
{
    public GameObject _captionText;
    public CreatureLocomotion _locomotion;
    public GameObject _spawner;

    void Awake()
    {
        Runner.Add(new FadeUpText(_captionText, "Every story has an end, every journey has a destination.", 1, 5, 1));
        Runner.Add(new FadeUpText(_captionText, "For the creature the journey ends with enlightenment.", 1, 5, 1));
        Runner.Add(new ToggleActivateAction(_spawner, true));
        Runner.Add(new FadeUpText(_captionText, "The creature sees the messages appear above and must raise itself to reach them.", 1, 5, 1));
        Runner.Add(new PerformAction(() =>
        {
            var spawner = _spawner.GetComponent<StrangeObjectSpawner>();
            spawner.EnableDrop(true);
            _locomotion.EnableJump(true);
            _locomotion.EnlightenmentAchieved += Locomotion_EnlightenmentAchieved;
        }));
    }

    private void Locomotion_EnlightenmentAchieved(object sender, System.EventArgs e)
    {
        var spawner = _spawner.GetComponent<StrangeObjectSpawner>();
        spawner.EnableDrop(false);
        _locomotion.EnlightenmentAchieved -= Locomotion_EnlightenmentAchieved;
    }
}
