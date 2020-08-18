using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] public StageWindowView stageWindowView;
    [SerializeField] public MainMenuWindowView menuWindowView;

    public void ToggleWindows(StageName stageName)
    {
        if (stageName == StageName.MainMenu)
        {
            menuWindowView.gameObject.SetActive(true);
            stageWindowView.gameObject.SetActive(false);
        }
        else
        {
            stageWindowView.gameObject.SetActive(true);
            menuWindowView.gameObject.SetActive(false);
            stageWindowView.ChangeStageTitle(stageName);
        }
    }
}