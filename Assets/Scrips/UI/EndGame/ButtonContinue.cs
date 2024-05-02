using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonContinue : MonoBehaviour
{
    private int indexMainMenu = 0;

    public void OnClickButton()
    {
        SceneManager.LoadScene(indexMainMenu);
        Time.timeScale = 1f;
    }
}
