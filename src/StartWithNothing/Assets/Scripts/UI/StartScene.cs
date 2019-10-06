using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartScene : MonoBehaviour
{
    public CanvasGroup _canvasGroup;
    public float _duration = 1f;
    public string _sceneName;
    
    void Awake()
    {
        var button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(new UnityAction(() =>
            {
                button.onClick.RemoveAllListeners(); // Prevent the ole double bounce
                if (_canvasGroup != null)
                {
                    StartCoroutine(FadeOut());
                }
                else
                {
                    SceneManager.LoadScene(_sceneName);
                }
            }));
        }
    }

    IEnumerator FadeOut()
    {
        float time = 0f;
        while (time < 1f)
        {
            _canvasGroup.alpha = Mathf.Lerp(0, 1, time);
            time += Time.deltaTime / _duration;
            yield return null;
        }

        _canvasGroup.alpha = 1;
        SceneManager.LoadScene(_sceneName);
    }
}
