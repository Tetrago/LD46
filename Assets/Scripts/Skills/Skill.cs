using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public int stageActive_;
    public float cooldown_;

    private float currentCooldown_;

    public void Use(Drip drip, PlayerController player)
    {
        if(!(WaveSpawner.waveCounter_ >= stageActive_
            && currentCooldown_ + cooldown_ <= Time.time)) return;

        Sound.Instance.Play(player.transform.position, Resources.Load<AudioClip>("Skill"));

        currentCooldown_ = Time.time;
        Activate(drip, player);
    }

    public void Update()
    {
        UnityEngine.UI.Image image = GetComponent<UnityEngine.UI.Image>();

        Color col = image.color;
        col.a = !(WaveSpawner.waveCounter_ >= stageActive_
            && currentCooldown_ + cooldown_ <= Time.time)
            ? 0.3f
            : 1;
        image.color = col;
    }

    protected abstract void Activate(Drip drip, PlayerController player);
}
