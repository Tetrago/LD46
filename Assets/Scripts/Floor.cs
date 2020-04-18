using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject tile_;
    public float range_;
    public float zValue_;

    private Dictionary<Vector3, GameObject> tiles_;
    private GameObject container_;

    private void Awake()
    {
        tiles_ = new Dictionary<Vector3, GameObject>();
        container_ = new GameObject("Tiles");
    }

    private void Update()
    {
        Vector3 pos = new Vector3(
            Mathf.Floor(transform.position.x),
            Mathf.Floor(transform.position.y),
            zValue_);

        List<Vector3> removals = new List<Vector3>();

        foreach(GameObject child in tiles_.Values)
        {
            if(Vector3.Distance(pos, child.transform.position) > range_)
            {
                Destroy(child);
                removals.Add(child.transform.position);
            }
        }

        removals.ForEach(vec => tiles_.Remove(vec));

        for(float x = -range_; x < range_; ++x)
        {
            for(float y = -range_; y < range_; ++y)
            {
                Vector3 loc = pos + new Vector3(x, y);

                if(!tiles_.ContainsKey(loc) && Vector3.Distance(pos, loc) < range_)
                {
                    tiles_[loc] = (GameObject)Instantiate(tile_, loc, Quaternion.identity, container_.transform);
                }
            }
        }
    }
}
