using UnityEngine;

public class PlaceBarrierSkill : Skill
{
    public GameObject shield_;

    protected override void Activate(Drip drip, PlayerController player)
    {
        Place(player.transform.position, Vector2.up);
        Place(player.transform.position, Vector2.right);
        Place(player.transform.position, Vector2.down);
        Place(player.transform.position, Vector2.left);
    }

    private void Place(Vector3 pos, Vector2 dir)
    {
        Decay decay = Instantiate(shield_, pos, Util.LookAt(dir))
            .AddComponent<Decay>();

        decay.decay_ = 0.1f;
        decay.renderer_ = decay.GetComponentInChildren<SpriteRenderer>();
        decay.transform.localScale = Vector3.one * 2;
    }
}
