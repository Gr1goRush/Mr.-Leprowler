using System;

public static class Settings
{
    public static event Action OnSettingsChange;

    public static float Volume { get; private set; } = 1f;
    public static bool VibroEnabled { get; private set; } = true;
    public static bool MusicEnabled { get; private set; } = true;

    public static void SetVolume(float volume)
    {
        Volume = volume;
        OnSettingsChange?.Invoke();
    }

    public static void SetVibration(bool state)
    {
        VibroEnabled = state;
        OnSettingsChange?.Invoke();
    }

    public static void SetMusic(bool state)
    {
        MusicEnabled = state;
        OnSettingsChange?.Invoke();
    }
}
