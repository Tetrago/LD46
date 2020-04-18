using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera_;
    public GameObject cursor_;
    public GameObject highligher_;
    public GameObject drip_;

    public float moveSpeed_;

    private SpriteRenderer cursorRenderer_;

    private void Awake()
    {
        cursorRenderer_ = cursor_.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        UpdateCursor();
        UpdateHighlighter();
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

        Vector3 diff = cursor_.transform.position;
        diff -= transform.position;

        float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        cursor_.transform.rotation = Quaternion.Euler(0, 0, rot - 90);

        Color col = cursorRenderer_.color;
        col.a = Mathf.Min(1, diff.magnitude);
        cursorRenderer_.color = col;
    }

    private void UpdateHighlighter()
    {
        Vector3 diff = drip_.transform.position;
        diff -= transform.position;

        float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        highligher_.transform.rotation = Quaternion.Euler(0, 0, rot - 90);
        highligher_.transform.position = transform.position;
    }
}
