using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [System.Serializable]
    public class Pool 
    {
        public string _parentName;
        public GameObject _prefab;
        public int _poolSize;
        public List<GameObject> _pooledObjects; 
    }

    [SerializeField] List<Pool> _pools;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;    
        }
    }
  
   void Start()
    {

        GameObject obj;

        foreach (Pool _pool in _pools)
        {
            GameObject parent = new GameObject(_pool._parentName);

            for (int i = 0; i < _pool._poolSize; i++)
            {
                obj = Instantiate(_pool._prefab);
                obj.transform.SetParent(parent.transform);
                obj.SetActive(false);
                _pool._pooledObjects.Add(obj);
            }
        }

    }

    public GameObject GetPooledObjects(int _selectedPool, Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < _pools[_selectedPool]._poolSize; i++)
        {
            if(!_pools[_selectedPool]._pooledObjects[i].activeInHierarchy)
            {
                GameObject _objectToSpawn;
                _objectToSpawn = _pools[_selectedPool]._pooledObjects[i];
                _objectToSpawn.transform.position = position;
                _objectToSpawn.transform.rotation = rotation;
                return _objectToSpawn;
            }
        }

        return null;
    }
   
}
