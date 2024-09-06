using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Retranslate : MonoBehaviour
{
    public UnityEvent OnSignalTranslatedC1;
    public UnityEvent OnSignalTranslatedC2;
    public void SendSignalC1()
    {
        OnSignalTranslatedC1?.Invoke();
    }

    public void SendSignalC2()
    {
        OnSignalTranslatedC1?.Invoke();
    }
}
