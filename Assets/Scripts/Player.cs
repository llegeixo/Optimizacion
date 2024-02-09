using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _gunPosition;
    [SerializeField] int _bulletType = 0;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject _bullet = PoolManager.Instance.GetPooledObjects(_bulletType, _gunPosition.position, _gunPosition.rotation);
            if(_bullet != null)
            {
                _bullet.SetActive(true);
            }
            else
            {
                Debug.LogError("Pool es demasiado pequeño");
            }
        }
    }
}
