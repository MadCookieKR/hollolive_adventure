using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SimpleEnemyBattle : InputSource
{
    public Character player;

    private CompositeDisposable disposables = new CompositeDisposable();

    private void Update()
    {
        command.OnNext(new Command.Attack(player));
    }

}
