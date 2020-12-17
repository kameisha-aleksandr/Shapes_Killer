using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bullets;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5;
    public float frequency = 1;
    public Vector3 dir = Vector3.left;
    
    void Start()
    {
        bullets = transform.Find("Muzzle");
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (Application.isPlaying)
        {
            CreateBullet();
            yield return new WaitForSeconds(frequency);
        }
    }
    
    void CreateBullet()
    {
        if (bulletPrefab != null)
        {
            GameObject bltGo = Instantiate(bulletPrefab,
                bullets.transform.position, bullets.transform.rotation, bullets);
            Rigidbody rigidB = bltGo.GetComponent<Rigidbody>();
            rigidB.velocity = dir * bulletSpeed;
        }
    }

    public void SliderChanged(float value)
    {
        frequency = value;
    }
}
