using UnityEngine;

public class Walk : MonoBehaviour
{
    public float moveSpeed_;

    private GameObject drip_;

    private void Awake()
    {
        moveSpeed_ *= WaveSpawner.difficultyFactor_;
        drip_ = GameObject.FindGameObjectWithTag("Drip");
    }

    private void Update()
    {
        Vector2 move = drip_.transform.position - transform.position;
        transform.Translate(move.normalized * moveSpeed_ * Time.deltaTime);
    }
}
