using TMPro;
using UnityEngine;

public class UI_MessageLevel : MonoBehaviour
{
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
    }
}
