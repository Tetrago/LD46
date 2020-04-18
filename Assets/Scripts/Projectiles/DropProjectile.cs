using UnityEngine;

public class DropProjectile : Projectile
{
    protected override void Hit(Collider2D collision)
    {
        Fire fire = collision.GetComponent<Fire>();
        if(fire != null)
        {
            fire.Hit();
            Sound.Instance.Play(transform.position, Resources.Load<AudioClip>("Hit"));
            Destroy(gameObject);
        }
    }
}
