using UnityEngine;

public class Enemy : PhysicsObject
{
    [Header("Аттрибуты")]
    public float healthPoints = 100f;
    public float maxSpeed = 3f;

    public void Hurt(int Damage)
    {
        Debug.Log("Принял урон: " + Damage);

        healthPoints -= Damage;
    }


    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (healthPoints <= 0) Destroy(gameObject);

        move.x += 100;
    }

    //private void FixedUpdate()
    //{
    //    
    //}
}
