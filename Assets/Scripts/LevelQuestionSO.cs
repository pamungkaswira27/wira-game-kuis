using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Quiz Game/Level Question")]
public class LevelQuestionSO : ScriptableObject
{
    [System.Serializable]
    public struct Answers
    {
        public string answerText;
        public bool isCorrect;
    }

    public Sprite hintSprite;
    public string level;
    public string question;

    public Answers[] answers;
}
