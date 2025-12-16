using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentHeal : StatusEffect
{
    [SerializeField] private float healValue;

    public override void ExecuteEffect(IEffectable obj)
    {
        BaseCharacter character = (BaseCharacter)obj;
        Debug.Log(" executing permanent Heal!");
    }
}
