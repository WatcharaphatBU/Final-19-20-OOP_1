using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Weapon
{
    [SerializeField] private float speed;

    private void Start()
    {
        Damage = 10;
        speed = 6f * GetShootDirection();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
        {
            character.TakeDamage(this.Damage);
        }
    }
}
