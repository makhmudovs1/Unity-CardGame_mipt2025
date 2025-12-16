using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{

    [SerializeField] GameObject endScreenPanel;
    [SerializeField] GameObject endScreenObject;
    [SerializeField] Button winLooseScreenButton;
    [SerializeField] Button mainScreenButton;
    [SerializeField] Button nextStageButton;

    [SerializeField] Text mainTitle;
    [SerializeField] Text progressRatio;

    private static EndScreenManager instance;
    public static EndScreenManager GetInstance { get => instance; }

    private void Awake()
    {
        instance = this;       
        winLooseScreenButton.onClick.AddListener(ChangeEndScreenState);
        nextStageButton.onClick.AddListener(DungeonManager.GetInstance.ChangeLevel);

        mainScreenButton.onClick.AddListener(delegate { Loader.Load(Loader.Scenes.MainMenu); } );
    }

    public void ShowEndScreen(bool isWon) {
        endScreenObject.SetActive(true);
        if (isWon)
        {
            mainTitle.text = "You won the battle";
            nextStageButton.interactable = true;
        }
        else mainTitle.text = "You lost the battle";

        progressRatio.text = (DungeonManager.GetInstance.Data.RoomPointer + 1) + "/" + (DungeonManager.GetInstance.Data.RoomsNumber+2);

    }

    void ChangeEndScreenState() {
        if(endScreenPanel.activeInHierarchy) endScreenPanel.SetActive(false);
        else endScreenPanel.SetActive(true);
    }

}
