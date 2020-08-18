public class StageWindowController
{
    private StageWindowView _stageWindowView;
    private GameController _gameController;

    public StageWindowController(StageWindowView stageWindowView, GameController gameController)
    {
        _stageWindowView = stageWindowView;
        _gameController = gameController;
        _stageWindowView.StageButtonClick += OnStageButtonClick;
    }

    private void OnStageButtonClick(StageName stageName)
    {
        _gameController.LoadStage(stageName);
    }
}