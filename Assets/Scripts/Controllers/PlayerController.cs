using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera_;
    public GameObject cursor_;
    public GameObject highligher_;
    public GameObject drip_;
    public GameObject dropProjectile_;

    public float moveSpeed_;
    public float shootTime_;

    private SpriteRenderer cursorRenderer_;
    private float lastShot_;

    private void Awake()
    {
        cursor_ = Instantiate(cursor_);
        highligher_ = Instantiate(highligher_);
        cursorRenderer_ = cursor_.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Fire();
        Move();
        UpdateCursor();
        UpdateHighlighter();
    }

    private void Fire()
    {
        if(Input.GetMouseButton(0))
        {
            if(lastShot_ <= Time.time - shootTime_)
            {
                Sound.Instance.Play(transform.position, Resources.Load<AudioClip>("Shoot"));
                GameObject proj = Instantiate(dropProjectile_, transform.position, Quaternion.identity);
                proj.GetComponent<Projectile>().Shoot(camera_.ScreenToWorldPoint(Input.mousePosition) - transform.position);
                lastShot_ = Time.time;
            }
        }
    }

    private void Move()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        transform.Translate(input * moveSpeed_ * Time.deltaTime);
    }

    private void UpdateCursor()
    {
        Vector3 pos = camera_.ScreenToWorldPoint(Input.mousePosition);
        pos.z = cursor_.transform.position.z;
        cursor_.transform.position = pos;

        Vector3 diff = cursor_.transform.position - transform.position;
        cursor_.transform.rotation = Util.LookAt(diff);

        Color col = cursorRenderer_.color;
        col.a = Mathf.Min(1, diff.magnitude);
        cursorRenderer_.color = col;
    }

    private void UpdateHighlighter()
    {
        Vector3 diff = drip_.transform.position - transform.position;

        highligher_.transform.rotation = Util.LookAt(diff);
        highligher_.transform.position = transform.position;
    }
}
