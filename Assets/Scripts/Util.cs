using UnityEngine;

public static class Util
{
    public static Quaternion LookAt(Vector2 diff)
    {
        float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, rot - 90);
    }
}
