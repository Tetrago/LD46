using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public SpriteRenderer renderer_;

    public float speed_;
    public float decay_;

    private void Update()
    {
        Color col = renderer_.color;
        col.a -= decay_ * Time.deltaTime;
        renderer_.color = col;

        if(col.a < 0)
        {
            Destroy(gameObject);
        }
    }

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
