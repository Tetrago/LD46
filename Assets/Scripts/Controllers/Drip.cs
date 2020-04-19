using System.Collections;
using UnityEngine;

public class Drip : MonoBehaviour
{
    public Animator animator_;
    public SpriteRenderer renderer_;
    public CameraFollower camera_;
    public Fade fade_;
    public GameObject light_;

    public Vector2 maxMovement_;
    public float minimumDistance_;
    public float moveFrequency_;
    public float moveSpeed_;
    public float stopRange_;

    private Vector3 destination_;
    private bool alive_;

    private void Awake()
    {
        alive_ = true;
    }

    private void Start()
    {
        StartCoroutine(PickNewDestination());
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, destination_) > stopRange_)
        {
            Move();
            animator_.SetBool("isWalking", true);
        }
        else
        {
            animator_.SetBool("isWalking", false);
        }
    }

    private void Move()
    {
        if(!alive_) return;

        transform.position = new Vector3(
            Mathf.SmoothStep(transform.position.x, destination_.x, moveSpeed_ * Time.deltaTime),
            Mathf.SmoothStep(transform.position.y, destination_.y, moveSpeed_ * Time.deltaTime),
            transform.position.z);
    }

    private void OnDrawGizmos()
    {
        if(destination_ != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(destination_, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Safe"))
        {
            Destroy(collision.gameObject);
            Sound.Instance.Play(transform.position, Resources.Load<AudioClip>("Hit"));

            if(alive_)
            {
                animator_.SetBool("isAlive", false);
                alive_ = false;

                StartCoroutine(GameEnd());
            }
        }
    }

    private IEnumerator PickNewDestination()
    {
        yield return new WaitForSeconds(moveFrequency_);

        Vector3 move;
        do
        {
            move = new Vector2(
                Random.Range(-maxMovement_.x, maxMovement_.x),
                Random.Range(-maxMovement_.y, maxMovement_.y));
        }
        while(move.magnitude < minimumDistance_);

        destination_ = transform.position + move;
        renderer_.flipX = move.x < 0;

        StartCoroutine(PickNewDestination());
    }

    private IEnumerator GameEnd()
    {
        camera_.target_ = transform;
        light_.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);

        Cursor.visible = true;
        EndGame.score_ = WaveSpawner.waveCounter_;
        fade_.ChangeScene(2);
    }
}
