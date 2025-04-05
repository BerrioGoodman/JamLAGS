using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool instance;
    public static BulletPool Instance 
    {
        get 
        {
            if (instance == null)
                Debug.Log("BulletPool instance missing");
            return instance;
        }
    }

    [SerializeField] private Bullet bulletPrefabs;
    [SerializeField] private int initialPoolSize = 10;
    private List<Bullet> bulletPool = new List<Bullet>();


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else 
        {
            instance = this;
        }
        AddBulletsToPool(initialPoolSize); 
    }

    void AddBulletsToPool(int amount) 
    {
        for (int i = 0; i < amount; i++) 
        {
            Bullet bullet = Instantiate(bulletPrefabs);
            bullet.gameObject.SetActive(false);
            bulletPool.Add(bullet);
            bullet.transform.parent = transform;
        }
        
    }

    public Bullet RequestBullet() 
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].gameObject.activeSelf) 
            {
                bulletPool[i].gameObject.SetActive(true);
                return bulletPool[i];
            }
        }
        AddBulletsToPool(1);
        bulletPool[bulletPool.Count - 1].gameObject.SetActive(true);
        return bulletPool[bulletPool.Count - 1];
    }
}
