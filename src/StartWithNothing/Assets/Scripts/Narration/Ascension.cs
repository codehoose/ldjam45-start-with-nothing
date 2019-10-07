using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ascension : NarrationBehaviour
{
    private bool _running = false;

    public GameObject _blackout;
    public GameObject _endGameText;

    void Awake()
    {
        Runner.Add(new FadeCanvas(_blackout, 1, 0, 1));
        Runner.Add(new FadeCanvas(_endGameText, 1, 0, 1));
        Runner.Add(new PerformAction(() =>
        {
            _running = true;
        }));
    }

    void Update()
    {
        if (!_running)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadMainMenu());
        }
    }

    IEnumerator LoadMainMenu()
    {
        yield return new FadeCanvas(_endGameText, 1, 1, 0).Execute();
        SceneManager.LoadScene("MainMenu");
    }
}
