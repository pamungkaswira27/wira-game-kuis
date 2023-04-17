using UnityEngine;

[CreateAssetMenu(fileName = "Level Pack", menuName = "Quiz Game/Level Pack")]
public class LevelPackSO : ScriptableObject
{
    [SerializeField] LevelQuestionSO[] _questions;

    public int QuestionCount => _questions.Length;

    public LevelQuestionSO GetQuestion(int index)
    {
        return _questions[index];
    }
}
