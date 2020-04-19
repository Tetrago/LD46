using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public static int score_;

    public Fade fade_;
    public TextMeshProUGUI text_;

    private static int Highscore
    {
        get => PlayerPrefs.GetInt("highscore", 0);
        set
        {
            if(value > Highscore)
            {
                PlayerPrefs.SetInt("highscore", value);
            }
        }
    }

    private void Start()
    {
        Sound.Instance.Play(Vector3.zero, Resources.Load<AudioClip>("Blip"));

        Highscore = score_;
        text_.text = string.Format("Score: {0}\nHighscore: {1}", score_, Highscore);
    }

    public void Retry()
    {
        Sound.Instance.Play(Vector3.zero, Resources.Load<AudioClip>("Blip"));

        fade_.ChangeScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
