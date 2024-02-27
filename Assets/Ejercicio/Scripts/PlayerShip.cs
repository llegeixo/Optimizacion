using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 50f;

    [SerializeField] Transform _pistolPosition;
    [SerializeField] int _bulletType = 0;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float _horizontalMovement = Input.GetAxis("Horizontal");

        
        Vector3 _movement = new Vector3(0f, 0f, _horizontalMovement);
        transform.Translate(_movement * _playerSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject _laser = PoolManagerEj.Instance.GetPooledObjects(_bulletType, _pistolPosition.position, _pistolPosition.rotation);
            if(_laser != null)
            {
                _laser.SetActive(true);
            }
            else
            {
                Debug.LogError("Pool es demasiado pequeño");
            }
        }
    }
}
