using System;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public Drip drip_;
    public PlayerController player_;
    public Skill[] skills_;

    private static readonly KeyCode[] keyCodes =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9
    };

    private void Update()
    {
        for(int i = 0; i < Mathf.Min(skills_.Length, keyCodes.Length); ++i)
        {
            if(Input.GetKeyDown(keyCodes[i]))
            {
                skills_[i].Use(drip_, player_);
            }
        }
    }
}
