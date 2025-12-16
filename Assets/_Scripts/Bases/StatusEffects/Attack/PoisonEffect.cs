using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


class PoisonEffect: StatusEffect
{
    private float fullDamage;

    private int _durationCounter = 0;

    public float FullDamage { get => fullDamage; set => fullDamage = value; }
    public override void ExecuteEffect(IEffectable obj)
    {
        BaseCharacter character = (BaseCharacter)obj;
        Debug.Log("Poison executer!");
    }
}

