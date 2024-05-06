using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerChest
{
    public static int CurrentChest { get; private set; } = 0;

    public static bool GivenChest { get; private set; } = false;

    private static List<Chest> _chests = new List<Chest>();

    public static void ChangeChest(int index)
    {
        CurrentChest = index;
        GivenChest = true;
    }

    public static int GiveChest()
    {
        GivenChest = false;
        return CurrentChest;
    }
}
