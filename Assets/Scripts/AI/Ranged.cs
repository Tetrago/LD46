using UnityEngine;

public class Ranged : MonoBehaviour
{
    public float moveSpeed_;
    public float range_;
    public float shootSpeed_;
    public GameObject fireProjectile_;

    private GameObject drip_;
    private bool shooting_;
    private float lastShot_;

    private void Awake()
    {
        moveSpeed_ *= WaveSpawner.difficultyFactor_;
        drip_ = GameObject.FindGameObjectWithTag("Drip");
    }

    private void Update()
    {
        if(!shooting_)
        {
            Vector2 move = drip_.transform.position - transform.position;
            transform.Translate(move.normalized * moveSpeed_ * Time.deltaTime);
        }
        else if(lastShot_ + shootSpeed_ <= Time.time)
        {
            Vector2 dir = drip_.transform.position - transform.position;
            Instantiate(fireProjectile_, transform.position, Quaternion.identity)
                .GetComponent<Projectile>()
                .Shoot(dir.normalized);

            lastShot_ = Time.time;
        }

        shooting_ = Vector2.Distance(transform.position, drip_.transform.position) <= range_;
    }
}
