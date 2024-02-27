using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float _laserSpeed = 400;

    void Update()
    {
        transform.position += transform.forward * _laserSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
