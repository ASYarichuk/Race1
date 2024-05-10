using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerChest
{
    public static bool GivenChest { get; private set; } = false;

    private static GameObject[] _chests = new GameObject[4]
    {
        new GameObject(),
        new GameObject(),
        new GameObject(),
        new GameObject()
    };

    public static int CurrentCount { get; private set; } = 0;
    private static int _maxCount = 4;

    public static GameObject TempChest { get; private set; }

    private static bool _isFindVoidPlace = false;

    public static GameObject GiveChest(int index)
    {
        return _chests[index];
    }

    public static void SetTempChest(GameObject chest)
    {
        TempChest = chest;
    }

    public static void AddChest(List<Table> tables)
    {
        if (CurrentCount < _maxCount)
        {
            CheckChests(TempChest, tables);
            _isFindVoidPlace = false;
            CurrentCount++;
        }
    }

    private static void CheckChests(GameObject chest, List<Table> tables)
    {
        for (int i = 0; i < _chests.Length && _isFindVoidPlace == false; i++)
        {
            if (_chests[i].TryGetComponent(out Chest newChest))
            {
                if (tables[i].GiveState())
                {
                    AddChestInList(chest, i, tables);
                    _isFindVoidPlace = true;
                }
            }
        }
    }

    private static void AddChestInList(GameObject chest, int indexCurrentPlace, List<Table> tables)
    {
        _chests[indexCurrentPlace] = chest;
        tables[indexCurrentPlace].ChangeState();
    }

}
