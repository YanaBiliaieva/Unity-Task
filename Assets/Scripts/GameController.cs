using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    private WindowsManager _windowsManager;
    private StageName _currentStage;
    private GameObject _currentContent;
    private readonly Dictionary<StageName, string> _stageContentDictionary = new Dictionary<StageName, string>();


    public GameController(WindowsManager windowsManager)
    {
        _windowsManager = windowsManager;

        _stageContentDictionary.Add(StageName.Stage1, "Prefabs/Cube");
        _stageContentDictionary.Add(StageName.Stage2, "Prefabs/Image");
        _stageContentDictionary.Add(StageName.Stage3, "Prefabs/ListItemsArea");
        _stageContentDictionary.Add(StageName.Stage4, "Prefabs/FallingFiguresSpawner");
    }

    public void LoadStage(StageName stageName)
    {
        if (_currentStage == stageName)
            return;

        _windowsManager.ToggleWindows(stageName);

        ClearCurrentContent(_currentContent);

        _currentStage = stageName;

        if (_stageContentDictionary.TryGetValue(stageName, out var contentPath))
        {
            InstantiateContent(contentPath);
        }
    }


    private void ClearCurrentContent(GameObject currentContent)
    {
        if (currentContent)
            GameObject.Destroy(currentContent);
    }

    private void InstantiateContent(string contentPath)
    {
        _currentContent = GameObject.Instantiate(Resources.Load(contentPath) as GameObject);
    }
}