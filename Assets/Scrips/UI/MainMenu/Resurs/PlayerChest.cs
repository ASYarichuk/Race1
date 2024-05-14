using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerChest
{
    public static bool GivenChest { get; private set; } = false;

    private static List<GameObject> _chests = new()
    {
        null,
        null,
        null,
        null
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

    public static void AddChest()
    {
        if (CurrentCount < _maxCount)
        {
            CheckTables();
            _isFindVoidPlace = false;
            CurrentCount++;
        }
    }

    private static void CheckTables()
    {
        for (int i = 0; i < _chests.Count && _isFindVoidPlace == false; i++)
        {
            if (Table.GiveState(i))
            {
                AddChestInList(i);
                _isFindVoidPlace = true;
            }
        }
    }

    private static void AddChestInList(int indexCurrentPlace)
    {
        _chests[indexCurrentPlace] = TempChest;
        Table.ChangeState(indexCurrentPlace);
    }

    public static void OpenChest()
    {
        if (_chests[0] != null)
        {
            _chests.Remove(_chests[0]);
            _chests.Add(null);
        }
    }
}
