using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePrefs : MonoBehaviour
{
    public void OnClickButton()
    {
        PlayerPrefs.DeleteAll();
    }
}
