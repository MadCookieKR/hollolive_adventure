using UniRx;
using UnityEngine;
using System;

public class BattleManager : MonoBehaviour
{
    public InputSource playerInput;
    public InputSource enemyInput;

    public Character player;
    public Character enemy;

    private bool isPlayerTurn = true;

    private CompositeDisposable disposables = new CompositeDisposable();

    // Start is called before the first frame update
    void Start()
    {
        IDisposable d1 = playerInput.command.Subscribe(command =>
        {
            if (isPlayerTurn)
            {
                player.handleCommand(command);
                isPlayerTurn = false;
            }
        });

        IDisposable d2 = enemyInput.command.Subscribe(command =>
        {
            if (!isPlayerTurn)
            {
                enemy.handleCommand(command);
                isPlayerTurn = true;
            }
        });

        disposables.Add(d1);
        disposables.Add(d2);
    }

    private void OnDestroy()
    {
        disposables.Dispose();
    }
}
