using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Question : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] TextMeshProUGUI _questionText;
    [SerializeField] Image _hintImage;

    public void SetQuestion(string levelText, string question, Sprite hint)
    {
        _levelText.text = levelText;
        _questionText.text = question;
        _hintImage.sprite = hint;
    }
}
