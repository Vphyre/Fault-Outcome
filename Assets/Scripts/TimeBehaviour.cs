using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeBehaviour : MonoBehaviour
{
    public Text timeText;
    public float stageTime;
    public static bool timeIsUp;
    public static bool stageClear;
    public static bool videoWatch;

    // Start is called before the first frame update
    void Start()
    {
        stageClear = false;
        videoWatch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stageClear && !videoWatch)
        {
            Clock();
        }
        else
        {
            timeIsUp = false;
        }
    }
    private void Clock()
    {
        if(stageTime>0)
        {
            stageTime -= Time.deltaTime;
            timeText.text = "00:"+ ((float)(Mathf.Round(stageTime))).ToString();
            timeIsUp = false;
        }
        else
        {
            stageTime = 0f;
            timeText.text = "00:0"+ ((float)(Mathf.Round(stageTime))).ToString();
            timeIsUp = true;
        }
    }
}
