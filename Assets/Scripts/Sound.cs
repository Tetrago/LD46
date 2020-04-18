using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance
    {
        get
        {
            if(instance_ == null)
            {
                instance_ = new GameObject("Sound").AddComponent<Sound>();
            }

            return instance_;
        }
    }

    private static Sound instance_;

    private AudioSource audio_;

    private void Awake()
    {
        audio_ = gameObject.AddComponent<AudioSource>();
    }

    public void Play(Vector3 pos, AudioClip clip)
    {
        transform.position = pos;
        audio_.clip = clip;
        audio_.Play();
    }
}
