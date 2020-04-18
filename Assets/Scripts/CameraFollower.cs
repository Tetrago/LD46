using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target_;
    public float moveSpeed_;

    private void Update()
    {
        Vector3 differance = target_.position - transform.position;
        transform.Translate((differance - Vector3.forward * differance.z) * moveSpeed_ * Time.deltaTime);
    }
}
