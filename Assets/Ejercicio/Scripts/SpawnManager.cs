using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform _spawnPosition;
    [SerializeField] int _bulletType = 1;
    GameObject _currentEnemy;

    void Start()
    {
        
        SpawnEnemy();
    }
    
    void Update()
    {
        
        if (_currentEnemy == null || !_currentEnemy.activeSelf)
        {
            
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        _currentEnemy = PoolManagerEj.Instance.GetPooledObjects(_bulletType, _spawnPosition.position, _spawnPosition.rotation);

        if (_currentEnemy != null)
        {
            _currentEnemy.SetActive(true);
        }
        else
        {
            Debug.LogError("Pool es demasiado pequeño");
        }
    }
}
