public class PlayerModelProvider
{
    public static PlayerModelProvider Instance
    {
        get
        {
            if(_instance != null)
            {
                return _instance;
            }

            _instance = new PlayerModelProvider();
            return _instance;
        }
    }
    static PlayerModelProvider _instance;

    public PlayerModel Model => _model ??= new PlayerModel();
    PlayerModel _model;
}   