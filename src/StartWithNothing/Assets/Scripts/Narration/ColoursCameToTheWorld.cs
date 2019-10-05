using System;
using UnityEngine;

public class ColoursCameToTheWorld : NarrationBehaviour
{
    private static readonly float DURATION = 3;

    private Material _groundMaterialStart;
    private Material _creatureMaterialStart;

    private Color _sky;
    private Color _skyNew;
    private float counter = 0;

    public GameObject _blackoutCurtain;
    public GameObject _captionText;
    public CreatureLocomotion _locomotion;
    public GameObject _nextStoryPoint;

    public Renderer _ground;
    public Renderer _creature;
    public Material _groundMaterial;
    public Material _creatureMaterial;

    void Awake()
    {
        _sky = Camera.main.backgroundColor;
        _skyNew = new Color(62 / 255f, 189 / 255f, 224 / 255f);

        _groundMaterialStart = _ground.material;
        _creatureMaterialStart = _creature.material;

        Runner.Add(new FadeCanvas(_blackoutCurtain, 0f, 0f, 0f));
        Runner.Add(new ChangeTextColourAction(_captionText, Color.black));
        Runner.Add(new ActivateCreatureAction(_locomotion, true));

        Runner.Add(new WaitAction(5));
        Runner.Add(new FadeUpText(_captionText, "This new world seemed a desolate place devoid of colour.", 0.5f, 5, 1));
        Runner.Add(new FadeUpText(_captionText, "The unseen hand uses the creature to paint colour into the world.", 0.5f, 5, 1));
        Runner.Add(new PerformAction(AddEventHandler));
    }

    void AddEventHandler()
    {
        _locomotion.Moved += Locomotion_Moved;
    }

    private void Locomotion_Moved(object sender, EventArgs e)
    {
        bool finish = false;
        counter += Time.deltaTime / DURATION;
        if (counter > 1)
        {
            counter = 1;
            finish = true;
        }

        _creature.material.Lerp(_creatureMaterialStart, _creatureMaterial, counter);
        _ground.material.Lerp(_groundMaterialStart, _groundMaterial, counter);
        Camera.main.backgroundColor = Color.Lerp(_sky, _skyNew, counter);
    
        if (finish)
        {
            _locomotion.Moved -= Locomotion_Moved;
            _nextStoryPoint.SetActive(true);
        }
    }
}
