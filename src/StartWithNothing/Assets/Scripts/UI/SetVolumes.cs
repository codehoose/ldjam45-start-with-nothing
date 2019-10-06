using UnityEngine;
using UnityEngine.Audio;

public class SetVolumes : MonoBehaviour
{
    public AudioMixer _audioMixer;

    void Start()
    {
        SetVolumeValue(VolumeNames.OverallVolume);
        SetVolumeValue(VolumeNames.MusicVolume);
        SetVolumeValue(VolumeNames.EffectsVolume);
    }

    private void SetVolumeValue(string volumeName)
    {
        _audioMixer.SetFloat(volumeName, PlayerPrefs.GetFloat(volumeName, 0));
    }
}
