using UnityEngine;
using System.Collections;

public class SetGameState : MonoBehaviour
{
    public GameStateManager.GameState targetState;

    IEnumerator Start()
    {
        // Esperar hasta que GameStateManager est� inicializado
        while (GameStateManager.INSTANCE == null)
        {
            yield return null;
        }

        GameStateManager.INSTANCE.ChangeState(targetState);
    }
}
