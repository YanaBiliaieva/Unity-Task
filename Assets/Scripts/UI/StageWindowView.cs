using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageWindowView : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Button stage1Button;
    [SerializeField] private Button stage2Button;
    [SerializeField] private Button stage3Button;
    [SerializeField] private Button stage4Button;
    [SerializeField] private Button closeButton;

    private readonly Dictionary<StageName, string> _stageTitles = new Dictionary<StageName, string>
    {
        {StageName.Stage1, "Stage 1"},
        {StageName.Stage2, "Stage 2"},
        {StageName.Stage3, "Stage 3"},
        {StageName.Stage4, "Stage 4"}
    };

    public event Action<StageName> StageButtonClick;

    void Start()
    {
        stage1Button.onClick.AddListener(() => StageButtonClick?.Invoke(StageName.Stage1));
        stage2Button.onClick.AddListener(() => StageButtonClick?.Invoke(StageName.Stage2));
        stage3Button.onClick.AddListener(() => StageButtonClick?.Invoke(StageName.Stage3));
        stage4Button.onClick.AddListener(() => StageButtonClick?.Invoke(StageName.Stage4));
        closeButton.onClick.AddListener(() => StageButtonClick?.Invoke(StageName.MainMenu));
    }

    public void ChangeStageTitle(StageName stageName)
    {
        _stageTitles.TryGetValue(stageName, out var formattedTitle);
        title.text = formattedTitle;
    }
}