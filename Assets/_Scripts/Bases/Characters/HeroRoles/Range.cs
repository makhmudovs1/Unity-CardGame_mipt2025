using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Range: HeroController
{
    public new static Player.Roles Role => Player.Roles.Range;

    public Range(HeroDisplay hero) : base(hero)
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
                    EnemyDisplay enemy;
                    if (EnemyDirector.GetInstance.Selected) enemy = EnemyDirector.GetInstance.Selected;
                    else enemy = EnemyDirector.GetInstance.FirstEnemy;

                    Damage(enemy, rangeStat);
                }
                break;

            case 10002:
                if (Player.GetInstance.HasAction(Role)) 
                {
                    Player.GetInstance.RemoveAction(Role);
                    PassTheTurn(Melee.Role);
                }
                break;

            case 10003:
                if (Player.GetInstance.HasAction(Role))
                {
                    Player.GetInstance.RemoveAction(Role);
                    PassTheTurn(Support.Role);
                }

                break;

            case 30001:
                if (Player.GetInstance.HasAction(Role))
                {
                    Player.GetInstance.RemoveAction(Role);

                    EnemyDisplay enemy;
                    if (EnemyDirector.GetInstance.Selected) enemy = EnemyDirector.GetInstance.Selected;
                    else enemy = EnemyDirector.GetInstance.FirstEnemy;
                    Damage(enemy, rangeStat);

                    var enemies = EnemyDirector.GetInstance.Enemies;

                    foreach (var e in enemies) 
                    {
                        if (e != enemy) Damage(e,meleeStat * 0.33f);
                    }
                }


                break;


            default:
                return;
        }
    }


}
