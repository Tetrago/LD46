using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int waveCounter_;
    public static float difficultyFactor_ = 1;

    public GameObject drip_;
    public EnemyDetail[] details_;
    public float difficultyIncrease_;
    public TextMeshProUGUI text_;
    public float safeDistance_;

    public void NewWave()
    {
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
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            NewWave();
        }
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
