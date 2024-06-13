using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePlate : MonoBehaviour
{
    [SerializeField] private int index;

    private bool isOpen = false;

    private void OnEnable()
    {
        isOpen = ListOfCardsWeapon.GiveStatusStateOpen(index);

        if (isOpen)
        {
            gameObject.SetActive(false);
        }
    }
}
