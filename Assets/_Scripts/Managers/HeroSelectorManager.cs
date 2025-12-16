using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectorManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject sender;

    [SerializeField] Transform content;

    [SerializeField] private GameObject elementPrefab;


    private static HeroSelectorManager instance;
    public static HeroSelectorManager GetInstance { get => instance; }
    public static GameObject Sender { get => instance.sender; set => instance.sender = value; }

    private void Awake()
    {        
        instance = this;
    }

    private void Update()
    {
        if (content.transform.childCount == 0) 
        {
            LoadHeroes(Player.GetInstance.Heroes);
        }
    }

    public void Close()
    {
        menu.SetActive(false);
        sender = null;
    }

    public void LoadHeroes(BaseHero[] heroes) {

        foreach (var hero in heroes) 
        { 
        var gameObject = Instantiate(elementPrefab);

        gameObject.transform.SetParent(content);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.transform.localPosition = new Vector3(0, 0, 0);

        gameObject.GetComponent<HeroMenuItemDisplay>().Hero = hero;
        }

    }
}
