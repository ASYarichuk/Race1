using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterBarrel : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;

    [SerializeField] private int _countBarrels = 5;
    [SerializeField] private int _startPoint = 0;

    [SerializeField] private GameObject _barrelPrefab;

    private void OnEnable()
    {
        List<int> numbers = new(_countBarrels);

        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i] = i;
        }

        for (int i = 0; i < _countBarrels; i++)
        {
            int numberSpawnPoint = Random.Range(_startPoint, numbers.Count);

            Instantiate(_barrelPrefab, _spawnPoints[numberSpawnPoint].transform);

            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[j] == 0)
                {

                }
            }
        }
    }
}
