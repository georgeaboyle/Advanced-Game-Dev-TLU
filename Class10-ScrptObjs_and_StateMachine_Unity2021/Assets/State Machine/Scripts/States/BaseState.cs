using UnityEngine;

public enum GameState { MainMenu, GameRunning, GamePaused }

public class BaseState : ScriptableObject
{
    public GameState state;
    public BaseState nextState;

    public virtual void Enter()
    {
        // Setting up before entering the loop

    }

    public virtual void Process()
    {
        // Constant loop

    }

    public virtual void Exit()
    {
        // Cleaning up before exiting the state
        GameManager.instance.ChangeState(nextState);
    }
}
