using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroDisplay : MonoBehaviour
{
    [SerializeField] private BaseHero hero;

    [SerializeField] int id;
    [SerializeField] private string heroName;
    [SerializeField] private string description;
    [SerializeField] private Image image;

    [SerializeField] private float supportStat;
    [SerializeField] private float rangeStat;
    [SerializeField] private float meleeStat;
    [SerializeField] private float baseHealth;

    private void Awake()
    {
        SetData();
    }

    public BaseHero Hero
    {
        get => hero;
        set
        {
            hero = value;
            SetData();
        }
    }

    public float SupportStat { get => supportStat; }
    public float RangeStat { get => rangeStat; }
    public float MeleeStat { get => meleeStat; }
    public float BaseHealth { get => baseHealth; }
    public int Id { get => id; }
    public string HeroName { get => heroName; }
    public string Description { get => description; }

    private void SetData()
    {
        if (!hero) return;
        id = hero.Id;
        image.sprite = hero.Sprite;
        heroName = hero.Name;
        description = hero.Description;
        baseHealth = hero.BaseHealth;

        supportStat = hero.SupportStat;
        rangeStat = hero.RangeStat;
        meleeStat = hero.MeleeStat;
    }
}
