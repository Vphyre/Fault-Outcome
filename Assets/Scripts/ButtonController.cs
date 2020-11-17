using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
  public void DESGRAÇADEUMAFUNCAO()
  {
		SceneManager.LoadScene(1);
	}
  public void BackToMenu()
  {
		SceneManager.LoadScene(0);
	}
  public void QuitGame()
  {
		Application.Quit(); 
	}
}
