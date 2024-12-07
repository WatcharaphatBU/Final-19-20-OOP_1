using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullets { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }

    [field: SerializeField] public float BulletReloadTime { get; set; }
    [field: SerializeField] public float BulletTimer { get; set; }

    public void Start()
    {
        Init(100);
    }
    public void Shoot()
    {
        //Leftclickshoot
        if (Input.GetButtonDown("Fire1") && BulletTimer <= 0)
        {
            GameObject obj = Instantiate(Bullets, BulletSpawnPoint.position, Quaternion.identity);
            Coin banana = obj.GetComponent<Coin>();
            banana.Init(10, this);
            BulletTimer = BulletReloadTime;
        }
    }
    private void FixedUpdate()
    {
        BulletTimer -= Time.deltaTime;
        Destroy();
    }
    public void Onhitwith()
    {

    }
    void Update()
    {
        Shoot();
    }
}