using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Cannon : Enemy, IShootable
{
    [SerializeField] private float attackRange;
    public Player player;

    [field: SerializeField] public GameObject Bullets {  get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint {  get; set; }

    [field: SerializeField] public float BulletReloadTime {  get; set; }
    [field: SerializeField] public float BulletTimer {  get; set; }

    public void Start()
    {
        Init(10);
    }
    private void Update()
    {
        BulletTimer -= Time.deltaTime;

        Behavior();

        if (BulletTimer < 0f)
        {
            BulletTimer = BulletReloadTime;
        }
        Destroy();
    }
    public override void Behavior()
    {
        Vector2 dicrection = player.transform.position - transform.position;
        float distance = dicrection.magnitude;

        if (distance < attackRange)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (BulletTimer <= 0f)
        {
            GameObject obj = Instantiate(Bullets, BulletSpawnPoint.position, Quaternion.identity);
            Rock rock = obj.GetComponent<Rock>();
            rock.Init(20, this);
        }
    }
}
