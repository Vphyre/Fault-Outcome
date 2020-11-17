using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBookBehaviour : MonoBehaviour
{
    public static bool canUse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenClose();
    }
    public void OpenClose()
    {
        if(InventoryBehaviour.logBook)
        {
            if(Input.GetKey(KeyCode.L))
            {
                print("Abriu log book");
            }
        }

    }
}
