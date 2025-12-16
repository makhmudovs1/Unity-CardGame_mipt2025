using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class BaseEnemy : BaseCharacter
{
    public enum Actions
    {
        Attack,
        Wait
    }
    [SerializeField] private float baseDamage;
    [SerializeField] private Actions[] actionStack;

    [SerializeField] private Color spriteColor;
    
    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
    public Actions[] ActionStack { get => actionStack; }
    public Color SpriteColor { get => spriteColor; set => spriteColor = value; }
}
