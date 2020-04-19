using UnityEngine;

public class Decay : MonoBehaviour
{
    public SpriteRenderer renderer_;
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
}
