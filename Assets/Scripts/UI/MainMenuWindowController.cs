public class MainMenuWindowController
{
    private MainMenuWindowView _menuWindowView;
    private GameController _gameController;

    public MainMenuWindowController(MainMenuWindowView menuWindowView, GameController gameController)
    {
        _menuWindowView = menuWindowView;
        _gameController = gameController;
        _menuWindowView.StageButtonClick += OnStageButtonClick;
    }

    private void OnStageButtonClick(StageName stageName)
    {
        _gameController.LoadStage(stageName);
    }
}