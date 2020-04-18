using UnityEngine;

public class Projectile : MonoBehaviour
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

    public void Shoot(Vector3 dir)
    {
        transform.rotation = Util.LookAt(dir);
        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed_;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
