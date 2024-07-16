using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterBarrel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints;

    [SerializeField] private int _countBarrels = 5;
    [SerializeField] private int _startPoint = 0;

    [SerializeField] private GameObject _barrelPrefab;

    private void OnEnable()
    {
        for (int i = 0; i < _countBarrels; i++)
        {
            int numberSpawnPoint = Random.Range(_startPoint, _spawnPoints.Count);

            Instantiate(_barrelPrefab, _spawnPoints[numberSpawnPoint].transform);

            _spawnPoints.Remove(_spawnPoints[numberSpawnPoint]);
        }
    }
}
