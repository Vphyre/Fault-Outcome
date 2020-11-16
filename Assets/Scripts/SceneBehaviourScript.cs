using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneBehaviourScript : MonoBehaviour
{
    public float tempo;
    private bool storyVideo;
    public GameObject storyText;
    private VideoPlayer videoPlayer;
    private AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        storyVideo = false;
        videoPlayer = GetComponent<VideoPlayer>();
        audioData = GetComponent<AudioSource>();
        audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        trocacena();
        StoryController();
    }
    void trocacena()
    {
        if(storyVideo)
        {
            tempo -=Time.deltaTime;
            if(tempo<=0)
            {
                SceneManager.LoadScene(2);
            }
        }
        
    }
    void StoryController()
    {
        if(!storyVideo)
        {
            if(Input.GetKey(KeyCode.E))
            {
                storyText.SetActive(false);
                videoPlayer.Play();
                storyVideo = true;
            }
        }       
    }
}
