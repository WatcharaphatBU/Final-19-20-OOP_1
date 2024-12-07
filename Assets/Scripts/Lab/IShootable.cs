using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    Transform BulletSpawnPoint { get; set; }
    GameObject Bullets { get; set; }

    float BulletReloadTime { get; set; }
    float BulletTimer { get; set; }
    void Shoot();
}
