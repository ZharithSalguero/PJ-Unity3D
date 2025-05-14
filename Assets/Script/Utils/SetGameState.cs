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
            Debug.LogError("GameStateManager.INSTANCE es null. Aseg�rate de que el GameObject con GameStateManager est� en la escena.");
        }
    }
}
