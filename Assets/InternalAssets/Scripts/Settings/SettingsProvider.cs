using UnityEngine;
using UnityEngine.UI;

public class SettingsProvider : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;

    private void Start()
    {
        if (_volumeSlider != null)
        {
            _volumeSlider.value = Settings.Volume;
        }
    }

    #region VolumeSetting
    public void SetVolume(float volume)
    {
        Settings.SetVolume(volume);
    }

    public void SetVolumeBySlider()
    {
        Settings.SetVolume(_volumeSlider.value);
    }

    #endregion


    #region VibrationSetting
    public void SetVibration(bool state)
    {
        Settings.SetVibration(state);
    }
    public void SwitchVibrationState()
    {
        Settings.SetVibration(!Settings.VibroEnabled);
    }
    #endregion


    #region MusicSetting
    public void SetMusic(bool state)
    {
        Settings.SetMusic(state);
    }

    public void SwitchMusicState()
    {
        Settings.SetMusic(!Settings.MusicEnabled);
    }

    #endregion
}
