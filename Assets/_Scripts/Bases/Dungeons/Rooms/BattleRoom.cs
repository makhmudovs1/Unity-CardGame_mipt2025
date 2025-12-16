using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BattleRoom : BaseRoom
{
    [SerializeField] private BaseEnemy[] enemies;
    public BaseEnemy[] Enemies { get => enemies; }
}
