using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    private BaseCharacter character;

    [SerializeField] private Image image;
    [SerializeField] private Text text;

    public BaseCharacter Hero { get => character;
        set
        {
            character = value;
            SetData();
        }
    }

    private void Awake()
    {
        SetData();
    }

    private void SetData() {   
        if (!character) return;
        image.sprite = character.Sprite;
        text.text = character.Name;
    }
}
