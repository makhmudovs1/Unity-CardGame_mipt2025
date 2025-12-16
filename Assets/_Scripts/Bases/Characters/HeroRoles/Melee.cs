using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Melee: HeroController
{
    public new static Player.Roles Role => Player.Roles.Melee;

    public Melee(HeroDisplay hero) : base(hero)
    { }

    public override void UseCard(int id)
    {

        base.UseCard(id);
        switch (id)
        {
            case 10001:
                if (Player.GetInstance.HasAction(Role))
                {
                    Player.GetInstance.RemoveAction(Role);
                    Damage(EnemyDirector.GetInstance.FirstEnemy, meleeStat);
                }
                break;

            case 10002:
                if (Player.GetInstance.HasAction(Role))
                {
                    Player.GetInstance.RemoveAction(Role);
                    PassTheTurn(Support.Role);
                }
                break;

            case 10003:
                if (Player.GetInstance.HasAction(Role))
                {
                    Player.GetInstance.RemoveAction(Role);
                    PassTheTurn(Range.Role);
                }

                break;

            case 40001:
                if (Player.GetInstance.HasAction(Role)) 
                {
                    Player.GetInstance.RemoveAction(Role);
                    Damage(EnemyDirector.GetInstance.FirstEnemy, meleeStat * 1.5f);
                }
                break;

            default:
                return;
        }
    }
}
