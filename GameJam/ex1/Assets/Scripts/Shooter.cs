using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Bullet bulletPrefab;


    public void Shoot(Transform loc)
    {
        Transform spawn = loc.transform.Find("BulletSpawn");
        Bullet bullet = GameObject.Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(rotation.x, spawn.eulerAngles.y, rotation.z);
        

    }

}
