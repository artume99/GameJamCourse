using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Bullet bulletPrefab;
    public Sprite[] bulletSprites;
    public static Shooter instance;
    public Sprite selectedBullet;

    private void Awake()
    {
        if (Shooter.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
       
    }

    public void Shoot(Transform loc)
    {
        Transform spawn = loc.transform.Find("BulletSpawn");
        Bullet bullet = GameObject.Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        // bullet.SetSprite(selectedBullet);
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(rotation.x, spawn.eulerAngles.y, rotation.z);
        
    }

    public void SetBulletSprite(Sprite bullet)
    {
        selectedBullet = bullet;
    }

}
