
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IHealable, IDamagable
{
    public enum Roles {
        Support,
        Range,
        Melee,
        Any
    }

    [SerializeField] private Text supActionText;
    [SerializeField] private Text ranActionText;
    [SerializeField] private Text melActionText;

    private static Player instance;

    [SerializeField] private PlayerData data;
    [SerializeField] float currentHealth;

    [SerializeField] float baseHealth;

    [SerializeField] private HeroSlot supportSlot;
    [SerializeField] private HeroSlot rangeSlot;
    [SerializeField] private HeroSlot meleeSlot;

    private Support support;
    private Range range;
    private Melee melee;

    [SerializeField] private List<Roles> availableActions = new List<Roles>();

    public void SetDefaultActions() {
        availableActions.Clear();
        availableActions.Add(Roles.Support);
        availableActions.Add(Roles.Range);
        availableActions.Add(Roles.Melee);
    }

    public Card[] Cards { get => data.Cards; }
    public BaseHero[] Heroes { get => data.Heroes; }

    public static Player GetInstance { get => instance; }
    public Support Support { get => support; }
    public Range Range { get => range; }
    public Melee Melee { get => melee; }

    public HeroSlot SupportSlot { get => supportSlot; }
    public HeroSlot RangeSlot { get => rangeSlot; }
    public HeroSlot MeleeSlot { get => meleeSlot; }
    public Roles[] AvailableActions { get => availableActions.ToArray(); }
    public PlayerData Data { get => data; }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        supActionText.text = SupportActionsNumber.ToString();
        ranActionText.text = RangeActionsNumber.ToString();
        melActionText.text = MeleeActionsNumber.ToString();
    }

    public int SupportActionsNumber { get => availableActions.FindAll(role => role.Equals(Roles.Support)).Count; }
    public int RangeActionsNumber { get => availableActions.FindAll(role => role.Equals(Roles.Range)).Count; }
    public int MeleeActionsNumber { get => availableActions.FindAll(role => role.Equals(Roles.Melee)).Count; }

    void SetData() {
        if (support == null && range == null && melee == null) return;

        baseHealth = support.BaseHealth + range.BaseHealth + melee.BaseHealth;
        currentHealth = baseHealth * data.HealthPercent;
    }

    public void SaveCurrentHealthPercent()
    {
        data.HealthPercent = currentHealth / baseHealth;
    }

    public void AddAction(Roles role) {
        availableActions.Add(role);
    }

    public void AddAction(Roles[] roles) {
        availableActions.AddRange(roles);
    }

    public void RemoveAction(Roles role) {

        availableActions.Remove(role);
    }

    public bool HasAction(Roles role)
    {
        if (!availableActions.Contains(role)) return false;
        else return true;
    }

    public bool ConfirmHeroes()
    {
        support = supportSlot.SetRole(Roles.Support) as Support;
        range = rangeSlot.SetRole(Roles.Range) as Range;
        melee = meleeSlot.SetRole(Roles.Melee) as Melee;

        if (SupportSlot.Hero.Hero == null || RangeSlot.Hero.Hero == null || MeleeSlot.Hero.Hero == null) return false;

        LockHeroes();
        SetData();

        return true;
    }

    public void LockHeroes()
    {
        supportSlot.GetComponent<OpenMenuOnClick>().enabled = false;
        rangeSlot.GetComponent<OpenMenuOnClick>().enabled = false;
        meleeSlot.GetComponent<OpenMenuOnClick>().enabled = false;
    }

    public void Heal(float health)
    {
        currentHealth += health;
        if (currentHealth >= baseHealth) currentHealth = baseHealth;
    }

    public void GetHit(float d)
    {
        currentHealth -= d;
    }

    public float GetBaseHealth()
    {
        return baseHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetActonNumberByRole(Roles role) {
        if (role == Roles.Support) return SupportActionsNumber;
        else if (role == Roles.Range) return RangeActionsNumber; 
        else if (role == Roles.Melee) return MeleeActionsNumber; 
        else return availableActions.Count; 
    }
}
