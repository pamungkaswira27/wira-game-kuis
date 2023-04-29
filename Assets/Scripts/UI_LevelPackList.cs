using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField] InitialGameplayData _initialGameplayData;
    [SerializeField] UI_LevelQuestionList _levelQuestionList;
    [SerializeField] UI_LevelPackButton _levelPackButton;
    [SerializeField] RectTransform _content;
    [SerializeField] Animator _animator;

    void Start()
    {
        // LoadLevelPack();

        if (_initialGameplayData.IsLose)
        {
            UI_LevelPackButton_OnLevelPackButtonClicked(null, _initialGameplayData.levelPack, false);
        }

        UI_LevelPackButton.OnLevelPackButtonClicked += UI_LevelPackButton_OnLevelPackButtonClicked;
    }

    void OnDestroy()
    {
        UI_LevelPackButton.OnLevelPackButtonClicked -= UI_LevelPackButton_OnLevelPackButtonClicked;
    }

    private void UI_LevelPackButton_OnLevelPackButtonClicked(UI_LevelPackButton levelPackButton, LevelPackSO levelPack, bool isLocked)
    {
        if (isLocked) return;

        // _levelQuestionList.gameObject.SetActive(true);
        _levelQuestionList.UnloadLevelPack(levelPack);

        // gameObject.SetActive(false);

        _initialGameplayData.levelPack = levelPack;

        _animator.SetTrigger("ToLevels");
    }

    public void LoadLevelPack(LevelPackSO[] levelPacks, PlayerProgressSO.MainData playerData)
    {
        foreach (LevelPackSO levelPack in levelPacks)
        {
            var button = Instantiate(_levelPackButton);
            button.SetLevelPack(levelPack);
            button.transform.SetParent(_content);
            button.transform.localScale = Vector3.one;

            if (!playerData.levelProgress.ContainsKey(levelPack.name))
            {
                button.LockLevelPack();
            }
        }
    }
}
