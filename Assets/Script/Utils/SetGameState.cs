using UnityEngine;

public class SetGameState : MonoBehaviour
{
    public GameStateManager.GameState targetState;

    void Start()
    {
        if (GameStateManager.INSTANCE != null)
        {
            GameStateManager.INSTANCE.ChangeState(targetState);
        }
        else
        {
            Debug.LogError("GameStateManager.INSTANCE es null. Asegúrate de que el GameObject con GameStateManager esté en la escena.");
        }
    }
}
