using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class EnemyDirector : MonoBehaviour
{
    private static EnemyDirector instance;

    [SerializeField] private EnemyDisplay selected;

    [SerializeField] private EnemyDisplay enemy1;
    [SerializeField] private EnemyDisplay enemy2;
    [SerializeField] private EnemyDisplay enemy3;

    public EnemyDisplay[] Enemies { get => new EnemyDisplay[] { enemy1, enemy2, enemy3 }; }

    public static EnemyDirector GetInstance { get => instance; }
      
    public EnemyDisplay FirstEnemy {
        get {
            foreach (EnemyDisplay enemy in Enemies) if (enemy.GetCurrentHealth() > 0) return enemy;
            
            return null;
        }
    }

    public EnemyDisplay Selected { get => selected;
        set 
        {
            if(selected)
                selected.GetComponent<EnemySelector>().DisableSelectImage();

            selected = value;
            if(selected)
                selected.GetComponent<EnemySelector>().EnableSelectImage();
        }
    }

    public void PerformActions() {
        foreach (var enemy in Enemies) enemy.PerformAction();
    }

    private void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {  
        Selected = enemy1;
    }

    private void Update()
    {
        if (selected && selected.GetCurrentHealth() <= 0) 
        {
            Selected = FirstEnemy;
        }
    }

    public void LoadEnemies(BaseEnemy[] enemies) 
    {
        for(int i = 0; i< Enemies.Length; i++) Enemies[i].Enemy = enemies[i];


    }

    public bool isEnemiesAlive() {
        foreach (var enemy in Enemies)
            if (enemy.GetCurrentHealth() > 0) return true;
        return false;
    }
}

