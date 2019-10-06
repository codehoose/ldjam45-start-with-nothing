using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderVolume : MonoBehaviour
{
    public AudioMixerGroup _audioMixerGroup;

    public string _volumeName;

    void Awake()
    {
        var slider = GetComponent<Slider>();
        if (slider)
        {
            slider.value = PlayerPrefs.GetFloat(_volumeName, 0);
            slider.onValueChanged.AddListener(new UnityAction<float>((sliderValue) =>
            {
                _audioMixerGroup.audioMixer.SetFloat(_volumeName, sliderValue);
                PlayerPrefs.SetFloat(_volumeName, sliderValue);
                PlayerPrefs.Save();
            }));
        }
    }
}
