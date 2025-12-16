using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider roomsNumberSlider;
    [SerializeField] private Text roomsNumberSliderValue;

    [SerializeField] private Slider eventRoomsNumberSlider;
    [SerializeField] private Text eventRoomsNumberSliderValue;

    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;


    private UIManager instance;
    public UIManager GetInstance { get => instance; }

    private void Awake()
    {
        startButton.onClick.AddListener(delegate { DungeonManager.GetInstance.StartDungeon(); });
        exitButton.onClick.AddListener(Exit);

        SetEventRoomsSliderMaxValue(roomsNumberSlider.value);
        roomsNumberSlider.onValueChanged.AddListener(delegate { SetEventRoomsSliderMaxValue(roomsNumberSlider.value); });
        instance = this;
    }

    void SetEventRoomsSliderMaxValue(float value) {
        eventRoomsNumberSlider.maxValue = value;
    }

    private void Update()
    {
        eventRoomsNumberSliderValue.text = eventRoomsNumberSlider.value.ToString();
        DungeonManager.GetInstance.Data.EventRoomsNumber = int.Parse(eventRoomsNumberSliderValue.text);

        roomsNumberSliderValue.text = roomsNumberSlider.value.ToString();
        DungeonManager.GetInstance.Data.RoomsNumber = int.Parse(roomsNumberSliderValue.text);
    }

    void Exit()
    {
        Application.Quit();
    }
}
