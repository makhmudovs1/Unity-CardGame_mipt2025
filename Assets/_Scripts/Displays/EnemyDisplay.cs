using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Actions = BaseEnemy.Actions;

public class EnemyDisplay : MonoBehaviour, IDamagable
{
    public UnityEvent OnHit = new();

    [SerializeField] private BaseEnemy enemy;

    [SerializeField] private int id;
    [SerializeField] private string enemyName;
    [SerializeField] private string description;
    [SerializeField] private Image image;
    [SerializeField] private float baseDamage;
    [SerializeField] private float baseHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] private Sprite[] states;
    [SerializeField] private Image actionStateImage;

    [SerializeField] private Actions[] actionStack;
    private int actionIndex = 0;

    private void Awake()
    {
        SetData();
    }

    private void Update()
    {
        if (actionStack[actionIndex] == Actions.Attack) actionStateImage.sprite = states[1];

        if (actionStack[actionIndex] == Actions.Wait) actionStateImage.sprite = states[0];
    }

    public BaseEnemy Enemy { get => enemy;
        set
        {
            enemy = value;
            SetData();
        }
    }

    private void SetData()
    {
        if (!enemy) return;
        id = enemy.Id;
        image.sprite = enemy.Sprite;
        enemyName = enemy.Name;
        description = enemy.Description;
        baseDamage = enemy.BaseDamage;
        baseHealth = enemy.BaseHealth;
        currentHealth = baseHealth;
        image.color = enemy.SpriteColor;
        actionStack = enemy.ActionStack;
    }

    public float GetBaseHealth()
    {
        return baseHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void GetHit(float d)
    {
        currentHealth -= d;   
        OnHit?.Invoke();

    }

    public void PerformAction() {
        if (currentHealth <= 0) return;

        if (actionStack[actionIndex] == Actions.Attack)
            Player.GetInstance.GetHit(baseDamage);
        else if (actionStack[actionIndex] == Actions.Wait) { }

        actionIndex++;
        if (actionIndex == actionStack.Length) actionIndex = 0;
    }
}
