using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        Sound.Instance.Play(Vector3.zero, Resources.Load<AudioClip>("Blip"));
        FindObjectOfType<Fade>().ChangeScene(1);
    }

    public void Quit()
    {
        Sound.Instance.Play(Vector3.zero, Resources.Load<AudioClip>("Blip"));
        Application.Quit();
    }
}
