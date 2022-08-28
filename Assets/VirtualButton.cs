using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Networking;

public class VirtualButton : MonoBehaviour
{
    public VirtualButtonBehaviour vb_on;
    public VirtualButtonBehaviour vb_off;
    public string url_on;
    public string url_off;

    IEnumerator Getrequest(string uri)
    {
        using (UnityWebRequest webrequest = UnityWebRequest.Get(uri))
        {
            yield return webrequest.SendWebRequest();
        }
    }
    void Start()
    {
        vb_on.RegisterOnButtonPressed(onbuttonpressed_on);
        vb_off.RegisterOnButtonPressed(onbuttonpressed_off);
    }
public void onbuttonpressed_on(VirtualButtonBehaviour vb_on)
    {
        StartCoroutine(Getrequest(url_on));
        Debug.Log("Led is on");
    }
    public void onbuttonpressed_off(VirtualButtonBehaviour vb_off)
    {
        StartCoroutine(Getrequest(url_off));
        Debug.Log("Led is off");
    }
}
