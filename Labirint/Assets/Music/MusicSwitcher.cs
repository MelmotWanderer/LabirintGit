using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MusicSwitcher : MonoBehaviour
{
    [SerializeField] private AudioClip _musicPlayerDetected;
    [SerializeField] private AudioClip _musicPlayerNotDetected;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void EnableMusicPlayerDetected()
    {
        if(_audioSource.clip == _musicPlayerDetected)
        {
            return;
        }
        _audioSource.clip = _musicPlayerDetected;
        _audioSource.Play();
    }
    public void EnableMusicPlayerNotDetected()
    {
        if (_audioSource.clip == _musicPlayerNotDetected)
        {
            return;
        }
        _audioSource.clip = _musicPlayerNotDetected;
        _audioSource.Play();
    }
}
