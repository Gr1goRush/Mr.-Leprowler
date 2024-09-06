using UnityEngine;

public static class Vibration
{
#if UNITY_IPHONE

    public static void PlayVibro()
    {
        if (!Settings.VibroEnabled) return; 
        Handheld.Vibrate();
    }

#else

    public static void PlayVibro() 
    {
        Debug.Log("Vibro");
    }


#endif

}
