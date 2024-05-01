using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarButton : MonoBehaviour
{
    [SerializeField] private GameObject _avatars;

    public void OnClickBetton()
    {
        _avatars.SetActive(true);
    }

}
