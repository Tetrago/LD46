using UnityEngine;

public class Music : MonoBehaviour
{
    public static bool playMusic_;

    private void Awake()
    {
        if(playMusic_)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
