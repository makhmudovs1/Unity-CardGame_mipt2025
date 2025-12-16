using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Support : HeroController
{
    public Support(HeroDisplay hero): base(hero)
    {}

    public new static Player.Roles Role => Player.Roles.Support;
    public override void UseCard(int id)
    {
        base.UseCard(id);
        switch (id)
        {
            case 10001:
                if (Player.GetInstance.HasAction(Role))
                { 
                    Player.GetInstance.RemoveAction(Role);
                    Heal(Player.GetInstance, supportStat);
                }
                   
                break;

            case 10002:
                if (Player.GetInstance.HasAction(Role))
                {
                    Player.GetInstance.RemoveAction(Role);
                    PassTheTurn(Range.Role);
                }
                break;

            case 10003:
                if (Player.GetInstance.HasAction(Role))
                {
                    Player.GetInstance.RemoveAction(Role);
                    PassTheTurn(Melee.Role);
                }
                break;

            case 20001:
                if (Player.GetInstance.HasAction(Role))
                {
                    Player.GetInstance.RemoveAction(Role);
                    Heal(Player.GetInstance, supportStat * 2);
                }
                break;

            default:
                return;
        }
    }


}
