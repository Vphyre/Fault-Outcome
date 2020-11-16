using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideosBehaviour : MonoBehaviour
{
    public VideoClip[] videoClips;
    private GameObject camera;
    private VideoPlayer videoPlayer;
    public static bool playVideo;
    public float videoTimer;
    public GameObject loopObj;
    public GameObject door;
    public GameObject doorOpened;
    public static bool loopLock;
    public int sceneNumber;
    public GameObject ground;
    public static AudioSource audioData;
    public GameObject status;
    public GameObject time;
    public GameObject item;

    
    // Start is called before the first frame update
    void Awake()
    {
        camera = GameObject.Find("Main Camera");
        videoPlayer = GetComponent<VideoPlayer>();
        audioData = GetComponent<AudioSource>();
        // status.SetActive(true);
        // time.SetActive(true);
        // item.SetActive(true);
    }
    void Start()
    {
        playVideo = false;
        loopLock = true;
        audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        playingVideos();
        HideLoop();
    }
    public void playingVideos()
    {
        if(playVideo)
        {
            videoPlayer.Play();
            videoTimer -= Time.deltaTime;
            PlayerBehaviour.canMove = false;
            audioData.Stop();
            status.SetActive(false);
            time.SetActive(false);
            item.SetActive(false);

            if(videoTimer<=0)
            {
                PlayerBehaviour.canMove = true;
                playVideo = false;
                SceneManager.LoadScene(sceneNumber);
            }   
        } 
    }
    public void HideLoop()
    {
        if(!loopLock)
        {
            loopObj.SetActive(false);
            door.SetActive(true);
            // door.transform.GetChild(0).gameObject.SetActive(true);
            doorOpened.SetActive(true);
            ground.SetActive(false);     
        }
    }
}
