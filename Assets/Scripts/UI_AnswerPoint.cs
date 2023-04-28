using System;
using TMPro;
using UnityEngine;

public class UI_AnswerPoint : MonoBehaviour
{
    public static event Action<string, bool> OnAnswerQuestion;

    // [SerializeField] UI_MessageLevel _messageUI;
    [SerializeField] TextMeshProUGUI _answerText;
    [SerializeField] bool _isCorrect;

    public void SelectAnswer()
    {
        // _messageUI.Message = $"Jawaban anda adalah {_answerText.text} ({ _isCorrect })";
        OnAnswerQuestion?.Invoke(_answerText.text, _isCorrect);
    }

    public void SetAnswer(string answer, bool isCorrect)
    {
        _answerText.text = answer;
        _isCorrect = isCorrect;
    }
}
