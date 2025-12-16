using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Roles = Player.Roles;


public class HeroSlot : MonoBehaviour
{
    private Roles role;

    [SerializeField] private HeroDisplay hero;
    private HeroController heroController;

    public HeroDisplay Hero { get => hero; 
        set { 
            hero = value;
        }
    }

    public HeroController SetRole(Roles role) {
        
        if (role == Roles.Melee) heroController = new Melee(hero);
        else if (role == Roles.Range) heroController = new Range(hero);
        if (role == Roles.Support) heroController = new Support(hero);
        this.role = role;

        return heroController;
    }

    public HeroController HeroController { get => heroController; }
    public Roles Role {get => role; }
}
