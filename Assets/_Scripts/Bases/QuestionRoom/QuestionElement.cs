using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionElement : MonoBehaviour
{
    [SerializeField] EventRoom roomData;
    [SerializeField] GameObject AnswerButtonPrefab;

    [SerializeField] Text question;
    [SerializeField] Transform answerHolder;
    [SerializeField] Image image;

    [SerializeField] GameObject resultScreen;

    [SerializeField] Button toResultsButton;

    [SerializeField] Button ReceiveTreasure;
    [SerializeField] Button ToNextStage;

    string[] answersStrings;
    string[] rightAnswerStrings;

    bool isRight = false;

    public string[] AnswersStrings { 
        get 
        {
            List<string> strings = new List<string>(answersStrings);
            strings.AddRange(rightAnswerStrings);
            return strings.ToArray();
        }
    }

    AnswerButton[] answers;
    AnswerButton[] rightAnswers;

    private void Awake()
    {
        if (roomData is QuestionRoom)
        { 
            var questionRoom = roomData as QuestionRoom;
            question.text = questionRoom.Question;

            rightAnswerStrings = questionRoom.RightAnswers; 
            answersStrings = questionRoom.AdditionalVariants;
        }

    }

    private void Start()
    {
        answers = answerHolder.GetComponentsInChildren<AnswerButton>();
        if(roomData is QuestionRoom) image.sprite = (roomData as QuestionRoom).Image;

        toResultsButton.onClick.AddListener(ChangeToResultScreen);

        List<AnswerButton> answersList = new();
        List<AnswerButton> rightAnswersList = new();

        List<string> strings = new List<string>(answersStrings);
        IListExtensions.Shuffle(strings);  
        
        foreach (var str in strings) 
        {
            var answer = Instantiate(AnswerButtonPrefab);
            var answerButton = answer.GetComponent<AnswerButton>();
            answerButton.Variant = str;

            answersList.Add(answerButton);
        }

        List<string> rightStrings = new List<string>(rightAnswerStrings);

        foreach (var str in rightStrings)
        {
            var answer = Instantiate(AnswerButtonPrefab);
            var answerButton = answer.GetComponent<AnswerButton>();
            answerButton.Variant = str;

            rightAnswersList.Add(answerButton);
        }

        answersList.AddRange(rightAnswersList);
        IListExtensions.Shuffle(answersList);

        answers = answersList.ToArray();
        rightAnswers = rightAnswersList.ToArray();

        foreach (var answer in answers)
        {
            answer.transform.SetParent(answerHolder);
            answer.transform.localScale = new Vector3(1, 1, 1);
            answer.transform.localPosition = new Vector3(answer.transform.localPosition.x, answer.transform.localPosition.y, answerHolder.position.z);

            answer.GetComponent<Button>().onClick.AddListener(delegate { Choose(answer); });
        }
    }

    public void Choose(AnswerButton button) {
        foreach (var answer in answers) 
        {
            answer.GetComponent<Button>().enabled = false;
            answer.GetComponent<Image>().color = Color.red;
        }

        foreach (var answer in rightAnswers) {

            if (answer == button) { isRight = true; }
            
        }
        
        if (isRight) 
        {
            foreach (var answer in rightAnswers)
            {
                answer.GetComponent<Image>().color = Color.green;
            }
        }

        ReviewToResultsButton();
    }

    void ReviewToResultsButton() 
    {
        toResultsButton.gameObject.SetActive(true);
    }

    void ChangeToResultScreen() 
    {
        gameObject.SetActive(false);
        resultScreen.SetActive(true);

        toResultsButton.gameObject.SetActive(false);

        LoadResultScreen();
    }

    void LoadResultScreen() 
    {
        ToNextStage.onClick.AddListener(DungeonManager.GetInstance.ChangeLevel);

        if (isRight)
        {
            ReceiveTreasure.interactable = true;
            ToNextStage.interactable = false;

            ReceiveTreasure.onClick.AddListener(OnGetTreasureClick);
        }
        else 
        {
            ReceiveTreasure.interactable = false;
            ToNextStage.interactable = true;
        }
    }

    void OnGetTreasureClick() 
    {
        GetTreasure();

        ReceiveTreasure.interactable = false;
        ToNextStage.interactable = true;
    }

    public UnityEvent OnGetTreasure = new();

    void GetTreasure() 
    {
        var reward = DungeonManager.GetInstance.GiveRandomReward();
        RewardMenuHandler.GetInstance.ShowItem(reward);

        OnGetTreasure?.Invoke();
    }
}
