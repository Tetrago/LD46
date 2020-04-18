using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator animator_;
    public float waitTime_;

    public void ChangeScene(int index)
    {
        StartCoroutine(LoadScene(index));
    }

    IEnumerator LoadScene(int index)
    {
        animator_.SetTrigger("Fade");

        yield return new WaitForSeconds(waitTime_);

        SceneManager.LoadScene(index);
    }
}
