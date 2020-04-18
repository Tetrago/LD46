using UnityEngine;

public class FireProjectile : Projectile
{
    protected override void Hit(Collider2D collision)
    {
        if(collision.CompareTag("Safe"))
        {
            Sound.Instance.Play(transform.position, Resources.Load<AudioClip>("Hit"));
            Destroy(gameObject);
        }
    }
}
