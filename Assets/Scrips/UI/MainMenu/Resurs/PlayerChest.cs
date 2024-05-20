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
    public static int MaxCount { get; private set; } = 4;

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
        if (CurrentCount < MaxCount)
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

    public static void ChangeStateChest(int index)
    {
        if (_chests[index] != null)
        {
            _chests[index].GetComponent<Chest>().ChangeState();
            _chests[index].GetComponent<Chest>().IsState();
        }
    }

    public static void OpenChest(int index)
    {
        if (_chests[index] != null)
        {
            _chests.Remove(_chests[index]);
            _chests.Add(null);
            Table.ChangeState(index);
            CurrentCount--;
        }
    }

    public static bool GiveStateChest(int index)
    {
        return _chests[index].GetComponent<Chest>().IsState();
    }
}
