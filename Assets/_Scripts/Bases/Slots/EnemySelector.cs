using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EnemySelector : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image selectionFrame;

    private EnemyDisplay enemy;

    public EnemyDisplay Enemy { get => enemy; }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (EnemyDirector.GetInstance.Selected == enemy)
        {
            EnemyDirector.GetInstance.Selected = null;
            return;
        }

        EnemyDirector.GetInstance.Selected = enemy;
    }

    private void Awake()
    {
        enemy = GetComponent<EnemyDisplay>();
    }

    public void EnableSelectImage() {
        selectionFrame.enabled = true;
    }

    public void DisableSelectImage() {
        selectionFrame.enabled = false;
    }
}
