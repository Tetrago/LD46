using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject tile_;
    public float range_;

    private Dictionary<Vector3, GameObject> tiles_;

    private void Update()
    {
        foreach(GameObject child in tiles_.Values)
        {
            if(Vector3.Distance(transform.position, child.transform.position) > range_)
            {
                Destroy(child);
            }
        }

        for(float x = -range_; x < range_; ++x)
        {
            for(float y = -range_; y < range_; ++y)
            {

            }
        }
    }
}
