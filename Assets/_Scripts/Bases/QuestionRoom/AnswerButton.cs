using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton: MonoBehaviour
{
    [SerializeField] string variant;

    [SerializeField] Text text;

    public string Variant { get => variant;
        set 
        { 
            variant = value;
            SetData();
        }
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    void SetData() 
    {
        text.text = variant;
    }
}
