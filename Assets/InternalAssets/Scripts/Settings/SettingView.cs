using UnityEngine;
using UnityEngine.UI;

public class SettingView : MonoBehaviour
{
    [SerializeField] private Image _vibroImage;
    [SerializeField] private Sprite _vibroEnabledSprite;
    [SerializeField] private Sprite _vibroDisabledSprite;

    [Space(20f)]
    [SerializeField] private Image _musicImage;
    [SerializeField] private Sprite _musicDisabledSprite;
    [SerializeField] private Sprite _musicEnabledSprite;

    private void OnEnable() => Settings.OnSettingsChange += UpdateView;
    private void OnDisable() => Settings.OnSettingsChange -= UpdateView;

    private void Start() => UpdateView();


    private void UpdateView()
    {
        _vibroImage.sprite = Settings.VibroEnabled ? _vibroEnabledSprite : _vibroDisabledSprite;
        _musicImage.sprite = Settings.MusicEnabled ? _musicEnabledSprite : _musicDisabledSprite;
    }
}
