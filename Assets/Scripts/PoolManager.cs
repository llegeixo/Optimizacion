using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [SerializeField] string _parentName;
    [SerializeField] GameObject _prefab;
    [SerializeField] int _poolSize;
    [SerializeField] List<GameObject> _pooledObjects; 

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
    // Start is called before the first frame update
    void Start()
    {
        GameObject parent = new GameObject(_parentName);

        GameObject obj;

        for (int i = 0; i < _poolSize; i++)
        {
            obj = Instantiate(_prefab);
            obj.transform.SetParent(parent.transform);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObjects(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if(!_pooledObjects[i].activeInHierarchy)
            {
                GameObject _objectToSpawn;
                _objectToSpawn = _pooledObjects[i];
                _objectToSpawn.transform.position = position;
                _objectToSpawn.transform.rotation = rotation;
                return _objectToSpawn;
            }
        }

        return null;
    }
   
}
