using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

[CreateAssetMenu]
public class BaseHero: BaseCharacter, ITreasure
{
    [SerializeField] private float supportStat;
    [SerializeField] private float rangeStat;

    [SerializeField] private float meleeStat;

    public float SupportStat { get => supportStat; set => supportStat = value; }
    public float RangeStat { get => rangeStat; set => rangeStat = value; }
    public float MeleeStat { get => meleeStat; set => meleeStat = value; }

    public string GetDescription()
    {
        return description;
    }

    public string GetName()
    {
        return "Hero: " + entityName;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }
}

