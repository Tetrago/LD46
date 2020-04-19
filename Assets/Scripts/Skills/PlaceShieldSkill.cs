using UnityEngine;

public class PlaceShieldSkill : Skill
{
    public GameObject shield_;

    protected override void Activate(Drip drip, PlayerController player)
    {
        Decay decay = Instantiate(shield_, player.transform.position, Util.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position))
            .AddComponent<Decay>();

        decay.decay_ = 0.1f;
        decay.renderer_ = decay.GetComponentInChildren<SpriteRenderer>();
        decay.transform.localScale = Vector3.one * 2;
    }
}
