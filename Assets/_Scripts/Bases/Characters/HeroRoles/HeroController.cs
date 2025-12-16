using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class HeroController
{
    public static UnityEvent OnCardUse = new();

    protected float baseHealth;
    protected float supportStat;
    protected float rangeStat;
    protected float meleeStat;

    public HeroController(HeroDisplay hero) {
        supportStat = hero.SupportStat;
        rangeStat = hero.RangeStat;
        meleeStat = hero.MeleeStat;

        baseHealth = hero.BaseHealth;
    }

    protected static Player.Roles Role => Player.Roles.Any;

    public float BaseHealth { get => baseHealth; }

    protected void PassTheTurn(Player.Roles role)
    {
        Player.GetInstance.RemoveAction(Role);
        Player.GetInstance.AddAction(role);
    }

    protected void Damage(IDamagable enemyTarget, float damage)
    {
        Player.GetInstance.RemoveAction(Role);
        enemyTarget.GetHit(damage); 
    }

    protected void Heal(IHealable healTarget, float heath)
    {
        Player.GetInstance.RemoveAction(Role);
        healTarget.Heal(heath);
    }

    public virtual void UseCard(int id)
    {
        OnCardUse.Invoke();
    }
}
