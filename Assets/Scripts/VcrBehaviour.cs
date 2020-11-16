using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VcrBehaviour : MonoBehaviour
{
    public GameObject vcr;
    public static GameObject tv;
    public float videoDuration;
    public static float videoDurationAux;
    public static bool resetTime;
    public static bool powerOn;
    // Start is called before the first frame update
    void Start()
    {
        tv = vcr.transform.GetChild(0).gameObject;
        videoDurationAux = videoDuration;
        resetTime = false;
        powerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        WatchTv();
    }
    public static void WatchTv()
    {
        if(powerOn)
        {
            if(videoDurationAux>0)
            {
                tv.SetActive(true);
                PlayerBehaviour.canMove = false;
                TimeBehaviour.videoWatch = true;
                VideosBehaviour.audioData.Pause();
            }
            else
            {
                tv.SetActive(false);
                powerOn = false;
                resetTime = true;
                PlayerBehaviour.canMove = true;
                TimeBehaviour.videoWatch = false;
                VideosBehaviour.audioData.UnPause();
            }
            videoDurationAux -= Time.deltaTime;
        }
      
    }
    private void ResetVideoTime()
    {
        if(resetTime)
        {
            videoDurationAux = videoDuration;
            resetTime = false;
        }
    }
}
