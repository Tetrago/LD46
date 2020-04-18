using UnityEngine;

public class Sound : MonoBehaviour
{
    public const int POOL_SIZE = 5;

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

    private AudioSource[] audio_;

    private void Awake()
    {
        audio_ = new AudioSource[POOL_SIZE];

        for(int i = 0; i < POOL_SIZE; ++i)
        {
            audio_[i] = new GameObject("Audio").AddComponent<AudioSource>();
            audio_[i].transform.parent = transform;
        }
    }

    public void Play(Vector3 pos, AudioClip clip)
    {
        foreach(AudioSource source in audio_)
        {
            if(!source.isPlaying)
            {
                source.clip = clip;
                source.transform.position = pos;
                source.Play();

                return;
            }
        }
    }
}
