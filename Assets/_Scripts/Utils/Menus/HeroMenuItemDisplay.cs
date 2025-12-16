using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroMenuItemDisplay : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private BaseHero hero;

    [SerializeField] private Image image;
    [SerializeField] private Text heroName;
    [SerializeField] private Text description;
    [SerializeField] private Text supportStat;
    [SerializeField] private Text rangeStat;
    [SerializeField] private Text meleeStat;

    [SerializeField] private GameObject sender;

    private void Awake()
    {
        if (hero) SetData();
    }

    public BaseHero Hero { get => hero; 
        set
        {
            hero = value;
            SetData();
        }
    }

    void SetData() {
        heroName.text = hero.Name;
        //description.text = hero.Description;
        image.sprite = hero.Sprite;
        supportStat.text = hero.SupportStat.ToString();
        rangeStat.text = hero.RangeStat.ToString();
        meleeStat.text = hero.MeleeStat.ToString();
    }

    public void SendHeroToSelectedSlot() {

        sender = HeroSelectorManager.Sender;
        var senderHeroSlot = sender.GetComponent<HeroSlot>();
        senderHeroSlot.Hero.Hero = hero;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SendHeroToSelectedSlot();
        HeroSelectorManager.GetInstance.Close();
    }
}
