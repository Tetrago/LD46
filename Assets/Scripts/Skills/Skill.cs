using System.Collections;
using UnityEngine;

public abstract class Skill
{
    public int stageActive_;
    public float cooldown_;

    private float currentCooldown_;

    public void Use(Drip drip, PlayerController player)
    {
        if(!(WaveSpawner.waveCounter_ >= stageActive_
            && currentCooldown_ + cooldown_ <= Time.time)) return;

        currentCooldown_ = Time.time;
        Activate(drip, player);
    }

    protected abstract void Activate(Drip drip, PlayerController player);
}
