using UnityEngine;

[CreateAssetMenu(fileName = "Level Pack", menuName = "Quiz Game/Level Pack")]
public class LevelPackSO : ScriptableObject
{
    [SerializeField] LevelQuestionSO[] _questions;
    [SerializeField] int _price;

    public int QuestionCount => _questions.Length;
    public int Price => _price;

    public LevelQuestionSO GetQuestion(int index)
    {
        return _questions[index];
    }
}
