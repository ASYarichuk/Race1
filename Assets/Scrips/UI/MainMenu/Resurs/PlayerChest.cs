using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerChest 
{
    public static int CurrentChest { get; private set; } = 0;

    public static void ChangeChest(int index)
    {
        CurrentChest = index;
        ChestsMenu.AddChest(index);
    }
}
