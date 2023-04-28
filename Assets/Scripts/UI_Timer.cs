using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    public static event Action OnTimeOver;

    [SerializeField] Slider _timerBar;
    //[SerializeField] UI_MessageLevel _messageUI;

    [SerializeField] float _answerTime;
    float _answerTimeRemaining;
    bool _isAnswering;

    public bool IsAnswering
    {
        get => _isAnswering;
        set => _isAnswering = value;
    }

    void Start()
    {
        ResetTimer();
        _isAnswering = true;
    }

    void Update()
    {
        if (!_isAnswering)
        {
            return;
        }

        _answerTimeRemaining -= Time.deltaTime;
        _timerBar.value = _answerTimeRemaining / _answerTime;

        if (_answerTimeRemaining < 0f)
        {
            //_messageUI.Message = "Waktu Habis";
            //_messageUI.gameObject.SetActive(true);

            OnTimeOver?.Invoke();
            _isAnswering = false;
            return;
        }
    }

    public void ResetTimer()
    {
        _answerTimeRemaining = _answerTime;
    }
}
