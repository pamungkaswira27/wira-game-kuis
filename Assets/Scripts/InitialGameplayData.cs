using UnityEngine;

[CreateAssetMenu(fileName = "Initial Data", menuName = "Quiz Game/Initial Data")]
public class InitialGameplayData : ScriptableObject
{
    public LevelPackSO levelPack;
    public int levelIndex;

    [SerializeField] bool _isLose;

    public bool IsLose
    {
        get => _isLose;
        set => _isLose = value;
    }
}
