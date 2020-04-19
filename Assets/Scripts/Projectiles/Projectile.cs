using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed_;

    public void Shoot(Vector2 dir)
    {
        transform.rotation = Util.LookAt(dir);
        GetComponent<Rigidbody2D>().velocity = dir * speed_;
    }

    protected abstract void Hit(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit(collision);
    }
}
