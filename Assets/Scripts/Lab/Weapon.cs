using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public void Init(int _damage, IShootable _shooter)
    {
        Damage = _damage;
        shooter = _shooter;
    }

    protected IShootable shooter;
    public abstract void OnHitWith(Character character);
    public abstract void Move();
    public int GetShootDirection()
    {
        float shootDir = shooter.BulletSpawnPoint.position.x - shooter.BulletSpawnPoint.parent.position.x;
        if (shootDir > 0)
        {
            return 1;
        }
        else return -1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject, 6f);
    }
}
