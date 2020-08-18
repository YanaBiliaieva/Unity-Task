using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindowView : MonoBehaviour
{
    [SerializeField] private Button stage1Button;
    [SerializeField] private Button stage2Button;
    [SerializeField] private Button stage3Button;
    [SerializeField] private Button stage4Button;

    public event Action<StageName> StageButtonClick;

    void Start()
    {
        stage1Button.onClick.AddListener(() => StageButtonClick?.Invoke(StageName.Stage1));
        stage2Button.onClick.AddListener(() => StageButtonClick?.Invoke(StageName.Stage2));
        stage3Button.onClick.AddListener(() => StageButtonClick?.Invoke(StageName.Stage3));
        stage4Button.onClick.AddListener(() => StageButtonClick?.Invoke(StageName.Stage4));
    }
}