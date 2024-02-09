using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _gunPosition;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject _bullet = PoolManager.Instance.GetPooledObjects(_gunPosition.position, _gunPosition.rotation);
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
