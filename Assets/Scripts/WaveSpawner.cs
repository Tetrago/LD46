using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int waveCounter_;
    public static float difficultyFactor_ = 1;

    public EnemyDetail[] details_;
    public float difficultyIncrease_;

    public void NewWave()
    {
        ++waveCounter_;
        difficultyFactor_ += difficultyIncrease_;

        foreach(EnemyDetail enemy in details_)
        {
            if(enemy.startingWave > waveCounter_) continue;

            for(float i = 0; i < enemy.baseCount * difficultyFactor_; ++i)
            {
                Vector2 pos = Random.onUnitSphere * enemy.baseRange * difficultyFactor_;
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
