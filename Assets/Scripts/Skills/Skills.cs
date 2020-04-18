using System;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public Drip drip_;
    public PlayerController player_;
    public string[] types_;

    private Skill[] skills_;

    private static readonly KeyCode[] keyCodes =
    {
        KeyCode.Alpha0,
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

    private void Awake()
    {
        skills_ = new Skill[types_.Length];

        for(int i = 0; i < types_.Length; ++i)
        {
            skills_[i] = (Skill)Activator.CreateInstance(Type.GetType(types_[i]));
        }
    }

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
