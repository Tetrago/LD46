using UnityEngine;

public class Fire : MonoBehaviour
{
    public float health_;

    public void Hit()
    {
        health_ -= 1;
        if(health_ == 0)
        {
            Destroy(gameObject);
        }
    }
}
