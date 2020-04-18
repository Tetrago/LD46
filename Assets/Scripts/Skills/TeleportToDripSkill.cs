using UnityEngine;

public class TeleportToDripSkill : Skill
{
    protected override void Activate(Drip drip, PlayerController player)
    {
        player.transform.position = drip.transform.position;
    }
}
