using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 5;

    void Update()
    {
        transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
