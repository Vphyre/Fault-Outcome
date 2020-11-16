using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemBehaviour : ItemBase
{
    public string itemName;
    public float itemSizeAux;
    public GameObject item;
    public string interactedTextAux;
    public string observedTextAux;
    public string caughtItemTextAux;    
    

    void Start()
    {
        itemCollider = false;
        itemTranform = GetComponent<Transform>();
        itemSize = itemSizeAux;
        interactButton = item.transform.GetChild(2).gameObject;
        observeButton = item.transform.GetChild(3).gameObject;

        interactedText = interactedTextAux;
        observedText = observedTextAux;
        caughtItemText = caughtItemTextAux;

        resetTime = 0;
        TimeBehaviour.timeIsUp = false;
        activedItem[0] = true;
        activedItem[1] = true;
        activedItem[2] = true;
        activedItem[3] = true;
        activedItem[6] = true;
        activedItem[7] = true;
        activedItem[8] = true;
        activedItem[9] = true;
        activedItem[10] = true;
        activedItem[11] = true;
        activedItem[12] = true;
        activedItem[13] = true;
        activedItem[14] = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        ItemFunction();
        if(TimeBehaviour.timeIsUp)
        {
            DisableAllItens();
        }
        // print(resetTime);
        // Debug.Log(item);
    }

    void ItemFunction()
    {
        if(itemCollider)
        {
           if(itemName == "VHS" && activedItem[0])
           {
                interactButton.SetActive(true);
                observeButton.SetActive(true);
                if(Input.GetKey(KeyCode.E))
                {
                    UiBehaviour.UiText = interactedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);
                    resetTime = 5f;
                    UiBehaviour.caughtItemString = caughtItemText;
                    activedItem[0] = false;
                    item.GetComponent<SpriteRenderer>().enabled = false;
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);   
                    resetTime = 5f;
                }
           }
           else if(itemName == "LoopObj" && activedItem[1])
           {
                VideosBehaviour.playVideo = true;
                activedItem[1] = false;
                PlayerBehaviour.canMove = false;
           }
           else if(itemName == "PictureBros" && activedItem[2])
           {      
                interactButton.SetActive(true);
                observeButton.SetActive(true);

                if(Input.GetKey(KeyCode.E))
                {
                    print(activedItem[0]);
                    print(activedItem[3]);
                    if(activedItem[0] || activedItem[3])
                    {
                        UiBehaviour.UiText = "I don't want to touch this dusty picture now...";
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                    }
                    else
                    {
                        UiBehaviour.UiText = interactedText;
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                        UiBehaviour.caughtItemString = caughtItemText;
                        activedItem[2] = false;
                        item.GetComponent<SpriteRenderer>().enabled = false;
                        activedItem[4] = true;
                        activedItem[0] = false;
                    }
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false); 
                    resetTime = 5f;  
                }
           }
           else if(itemName == "VCR" && activedItem[3])
           {      
                interactButton.SetActive(true);
                observeButton.SetActive(true);

                if(Input.GetKey(KeyCode.E))
                {
                    if(activedItem[0])
                    {
                        UiBehaviour.UiText = "I can't do anything without a VHS tape.";
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                    }
                    else
                    {
                        UiBehaviour.UiText = interactedText;
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                        UiBehaviour.caughtItemString = caughtItemText;
                        activedItem[3] = false;
                        VcrBehaviour.powerOn = true;
                    }
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false); 
                    resetTime = 5f;  
                }
           }
            else if(itemName == "PicturePlaced" && activedItem[4])
            {      
                interactButton.SetActive(true);
                observeButton.SetActive(true);

                if(Input.GetKey(KeyCode.E))
                {
                    UiBehaviour.UiText = interactedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);
                    resetTime = 5f;
                    UiBehaviour.caughtItemString = caughtItemText;
                    activedItem[4] = false;
                    activedItem[2] = false;
                    activedItem[5] = true;
                    activedItem[0]= false;
                    item.GetComponent<SpriteRenderer>().enabled = true;
                    VideosBehaviour.loopLock = false;
                    TimeBehaviour.stageClear = true;
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false); 
                    resetTime = 2f;  
                }
           }
           else if(itemName == "Door1" && activedItem[5])
           {
               SceneManager.LoadScene(3);
           }
           else if(itemName == "CurtainWindow" && activedItem[6])
           {
                interactButton.SetActive(true);
                observeButton.SetActive(true);

                if(Input.GetKey(KeyCode.E))
                {
                    UiBehaviour.UiText = interactedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);
                    resetTime = 5f;
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);   
                    resetTime = 5f;
                }
           }
           else if(itemName == "CleaningCloth" && activedItem[7])
           {
                interactButton.SetActive(true);
                observeButton.SetActive(true);

                if(Input.GetKey(KeyCode.E))
                {
                    if(!activedItem[10])
                    {
                        UiBehaviour.UiText = "I managed to clean the blue cup. But something made the cup disappear... Strange.";
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                        activedItem[7] = false;
                        UiBehaviour.caughtItemString = caughtItemText;
                    }
                    else if(!activedItem[8])
                    {
                        UiBehaviour.UiText = "The red cup is clean, I may have to do something else with it...";
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                    }
                    else
                    {
                        UiBehaviour.UiText =interactedText;
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                    }
                   
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);   
                    resetTime = 5f;
                }

                if(!activedItem[7] && !activedItem[8] && !activedItem[10] && !activedItem[11])
                {
                    VideosBehaviour.loopLock = false;
                    TimeBehaviour.stageClear = true;
                }
           }
           else if(itemName == "RedCup" && activedItem[8])
           {
                interactButton.SetActive(true);
                observeButton.SetActive(true);

                if(Input.GetKey(KeyCode.E))
                {
                    if(activedItem[10])
                    {
                        UiBehaviour.UiText = interactedText;
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                        item.GetComponent<SpriteRenderer>().enabled = false;
                        UiBehaviour.caughtItemString = caughtItemText;
                        activedItem[8] = false;
                    }
                    else if(!activedItem[7])
                    {
                        UiBehaviour.UiText = interactedText;
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                        item.GetComponent<SpriteRenderer>().enabled = false;
                        UiBehaviour.caughtItemString = caughtItemText;
                        activedItem[8] = false;
                    }
                    else
                    {
                        UiBehaviour.UiText = "I won't take the red cup now. I have to do something with the blue cup first ...";
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                    }
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);   
                    resetTime = 5f;
                }
           }
           else if(itemName == "Vase" && activedItem[9])
           {
                interactButton.SetActive(true);
                observeButton.SetActive(true);

                if(Input.GetKey(KeyCode.E))
                {
                    UiBehaviour.UiText = interactedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);
                    resetTime = 5f;
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);   
                    resetTime = 5f;
                }
           }
           else if(itemName == "BlueCup" && activedItem[10])
           {
                interactButton.SetActive(true);
                observeButton.SetActive(true);

                if(Input.GetKey(KeyCode.E))
                {
                    if(activedItem[8])
                    {
                        UiBehaviour.UiText = interactedText;
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                        item.GetComponent<SpriteRenderer>().enabled = false;
                        UiBehaviour.caughtItemString = caughtItemText;
                        activedItem[10] = false;
                    }
                    else if(!activedItem[11])
                    {
                        UiBehaviour.UiText = interactedText;
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                        item.GetComponent<SpriteRenderer>().enabled = false;
                        UiBehaviour.caughtItemString = caughtItemText;
                        activedItem[10] = false;
                    }
                    else
                    {
                        UiBehaviour.UiText = "I won't take the blue cup now. I have to do something with the red cup first ...";
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                    }
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);   
                    resetTime = 5f;
                }
           }
           else if(itemName == "Cafe" && activedItem[11])
           {
                interactButton.SetActive(true);
                observeButton.SetActive(true);
                
                if(Input.GetKey(KeyCode.E))
                {
                    if(!activedItem[8])
                    {
                        UiBehaviour.UiText = "Wow, this coffee smells good. It looked great in that red cup. But the cup disappeared mysteriously... bizarre.";
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                        activedItem[11] = false;
                        UiBehaviour.caughtItemString = caughtItemText;
                    }
                    else if(!activedItem[10])
                    {
                       UiBehaviour.UiText = "I will not put coffee in the filthy cup.";
                       interactButton.SetActive(false);
                       observeButton.SetActive(false);
                       resetTime = 5f;
                    }
                    else
                    {
                        UiBehaviour.UiText = interactedText;;
                        interactButton.SetActive(false);
                        observeButton.SetActive(false);
                        resetTime = 5f;
                    }
                
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);   
                    resetTime = 5f;
                }

                if(!activedItem[7] && !activedItem[8] && !activedItem[10] && !activedItem[11])
                {
                    VideosBehaviour.loopLock = false;
                    TimeBehaviour.stageClear = true;
                }
               
           }
           else if(itemName == "Door2" && activedItem[12])
           {
               SceneManager.LoadScene(4);
           }
           else if(itemName == "Door3" && activedItem[13])
           {
               SceneManager.LoadScene(5);
           }
           else if(itemName == "PictureFinal" && activedItem[14])
           {
                interactButton.SetActive(true);
                observeButton.SetActive(true);

                if(Input.GetKey(KeyCode.E))
                {
                    UiBehaviour.UiText = interactedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);
                    resetTime = 7f;
                    VideosBehaviour.loopLock = false;
                    TimeBehaviour.stageClear = true;
                    item.GetComponent<SpriteRenderer>().enabled = false;
                    UiBehaviour.caughtItemString = caughtItemText;
                }
                else if(Input.GetKey(KeyCode.R))
                {
                    UiBehaviour.UiText = observedText;
                    interactButton.SetActive(false);
                    observeButton.SetActive(false);   
                    resetTime = 5f;
                }
           }

           if(resetTime<=0)
           {
               UiBehaviour.UiText = "";
           }
           resetTime -= Time.deltaTime;
        }
        
        else
        {
           interactButton.SetActive(false);
           observeButton.SetActive(false);
           if(resetTime>=0)
           {
            //    UiBehaviour.UiText = "";
           }   
           resetTime -= Time.deltaTime;     
        }
    }    
    private void DisableAllItens()
    {
        activedItem[0] = false;
        activedItem[2] = false;
        activedItem[3] = false;
        activedItem[4] = false;
        activedItem[5] = false;
        activedItem[6] = false;
        activedItem[7] = false;
        activedItem[8] = false;
        activedItem[9] = false;
        activedItem[10] = false;
        activedItem[11] = false;
        activedItem[12] = false;
        activedItem[13] = false;
        activedItem[14] = false;
        activedItem[15] = false;
        activedItem[16] = false;
        activedItem[17] = false;
        activedItem[18] = false;
        activedItem[19] = false;
        activedItem[20] = false;
        activedItem[21] = false;
        activedItem[22] = false;
        activedItem[23] = false;
        activedItem[24] = false;
        activedItem[25] = false;
        activedItem[26] = false;
        activedItem[27] = false;
        activedItem[28] = false;
        activedItem[29] = false;
    }
}
