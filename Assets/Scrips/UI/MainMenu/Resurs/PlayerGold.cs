using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerGold
{
    public static int Gold { get; private set; } = 1000;

    public static void AddGold(int gold)
    {
        Gold += gold;
    }

    public static void RemoveGold(int gold)
    {
        Gold -= gold;
    }
}
