using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int waveCounter_;
    public static float difficultyFactor_ = 1;

    public Camera camera_;
    public GameObject drip_;
    public EnemyDetail[] details_;
    public float difficultyIncrease_;
    public TextMeshProUGUI text_;
    public float safeDistance_;
    public float waitTime_;
    public Image waitBar_;

    private float lastWait_;

    private void Awake()
    {
        lastWait_ = -1;
    }

    public void NewWave()
    {
        lastWait_ = -1;
        ++waveCounter_;
        difficultyFactor_ += difficultyIncrease_ * difficultyFactor_;

        text_.text = string.Format("{0:00}", waveCounter_);

        foreach(EnemyDetail enemy in details_)
        {
            if(enemy.startingWave > waveCounter_) continue;

            for(float i = 0; i < enemy.baseCount * difficultyFactor_; ++i)
            {
                Vector2 pos = Random.insideUnitCircle.normalized * Random.Range(safeDistance_, enemy.baseRange) * difficultyFactor_ + new Vector2(drip_.transform.position.x, drip_.transform.position.y);
                Instantiate(enemy.prefab, pos, Quaternion.identity, transform).name = enemy.name;
            }
        }
    }

    private void Update()
    {
        if(lastWait_ != -1)
        {
            SetBar((Time.time - lastWait_) / (waitTime_ - difficultyIncrease_ * difficultyFactor_) * Screen.width * 2);
        }
        else
        {
            SetBar(0);
        }

        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && lastWait_ == -1)
        {
            lastWait_ = Time.time;
        }

        if(lastWait_ != -1 && lastWait_ + waitTime_ - difficultyIncrease_ * difficultyFactor_ <= Time.time)
        {
            NewWave();
        }
    }

    private void SetBar(float size)
    {
        waitBar_.rectTransform.sizeDelta = new Vector2(size, waitBar_.rectTransform.sizeDelta.y);
    }

    [System.Serializable]
    public struct EnemyDetail
    {
        public string name;
        public GameObject prefab;
        public float startingWave;
        public float baseRange;
        public float baseCount;
    }
}
