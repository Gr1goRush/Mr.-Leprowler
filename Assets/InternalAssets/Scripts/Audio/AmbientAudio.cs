using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientAudio : MonoBehaviour
{
    [SerializeField, HideInInspector] private AudioSource m_AudioSource;

    private void OnValidate()
    {
        m_AudioSource ??= GetComponent<AudioSource>();
    }

    private void OnEnable() => Settings.OnSettingsChange += UpdateSettings;
    private void OnDisable() => Settings.OnSettingsChange -= UpdateSettings;

    private void Start()
    {
        UpdateSettings();
    }

    public void UpdateSettings()
    {
        m_AudioSource.volume = Settings.Volume;
        m_AudioSource.mute = !Settings.MusicEnabled;
    }
}
