using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiBehaviour : MonoBehaviour
{
    public Text SrinyText;
    public static string UiText; 
    public Text caughtItemText;
    public static string caughtItemString;
    // Start is called before the first frame update
    void Start()
    {
        UiText = "";
        SrinyText.text = "";
        caughtItemString = "No Item";
        caughtItemText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        SrinyText.text = UiText;
        caughtItemText.text = caughtItemString;
    }
}
