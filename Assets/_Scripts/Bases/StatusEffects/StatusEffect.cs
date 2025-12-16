using System;
using System.Collections;
using UnityEngine;


public abstract class StatusEffect: BaseEntity
{
    public StatusEffect() {
        entityName = "Status effect:\n";
        description = "[Status Effect]\n";
    }
     
    [SerializeField] protected int baseDuration = 0;
    public int BaseDuration { get { return baseDuration; } set { baseDuration = value; } }

    public abstract void ExecuteEffect(IEffectable obj);
}