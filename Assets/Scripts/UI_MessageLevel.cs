using TMPro;
using UnityEngine;

public class UI_MessageLevel : MonoBehaviour
{
    [SerializeField] GameObject _winOption;
    [SerializeField] GameObject _loseOption;
    [SerializeField] TextMeshProUGUI _messageText;

    public string Message
    {
        get => _messageText.text;
        set => _messageText.text = value;
    }

    void Awake()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        UI_Timer.OnTimeOver += UI_Timer_OnTimeOver;
        UI_AnswerPoint.OnAnswerQuestion += UI_AnswerPoint_OnAnswerQuestion;
    }

    void OnDestroy()
    {
        UI_Timer.OnTimeOver -= UI_Timer_OnTimeOver;
        UI_AnswerPoint.OnAnswerQuestion -= UI_AnswerPoint_OnAnswerQuestion;
    }

    private void UI_AnswerPoint_OnAnswerQuestion(string answerText, bool isCorrect)
    {
        Message = $"Jawaban Anda {isCorrect} (Jawab : {answerText})";
        gameObject.SetActive(true);

        if (isCorrect)
        {
            _winOption.SetActive(true);
            _loseOption.SetActive(false);
        }
        else
        {
            _winOption.SetActive(false);
            _loseOption.SetActive(true);
        }
    }

    private void UI_Timer_OnTimeOver()
    {
        Message = "Waktu Habis";
        gameObject.SetActive(true);

        _winOption.SetActive(false);
        _loseOption.SetActive(true);
    }
}
