using System.Collections;
using UnityEngine;

public class PlaySoundAction : BaseAction
{
    private AudioClip _clip;
    private AudioSource _audioSource;

    public PlaySoundAction(AudioClip clip, AudioSource audioSource)
    {
        _clip = clip;
        _audioSource = audioSource;
    }

    public override IEnumerator Execute()
    {
        _audioSource.PlayOneShot(_clip);
        yield return null;
    }

}
