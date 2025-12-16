using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject menuPrefab;
    [SerializeField] Transform position;
    [SerializeField] Canvas canvas;

    private static RewardMenuHandler instance;
    public static RewardMenuHandler GetInstance { get => instance; }

    private void Awake()
    {
        instance = this;
    }

    public void ShowItem(ITreasure treasure) {
        
        StartCoroutine(ShowAndClose(treasure.GetName(), treasure.GetDescription(), treasure.GetSprite()));
    }


    IEnumerator ShowAndClose(string name, string desc, Sprite sprite) 
    {

        var gameObject = Instantiate(menuPrefab);
        gameObject.transform.SetParent(position);

        gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.transform.localPosition = new Vector3(0, 0, 0);

        gameObject.GetComponent<RewardPopUp>().SetData(name, desc, sprite);

        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
