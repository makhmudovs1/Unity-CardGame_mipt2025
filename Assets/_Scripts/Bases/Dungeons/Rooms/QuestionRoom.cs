using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestionRoom : EventRoom
{
    [SerializeField] private string question;

    [SerializeField] private string[] additionalVariants;
    [SerializeField] private string[] rightAnswers;

    [SerializeField] private Sprite image;

    public string Question { get => question; }
    public string[] AdditionalVariants { get => additionalVariants; }
    public string[] RightAnswers { get => rightAnswers; }
    public Sprite Image { get => image; }
}
