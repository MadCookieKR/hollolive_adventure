using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Character : MonoBehaviour, CommandConsumer
{
    public abstract Stats getStats();
    public abstract void handleCommand(Command c);

    public abstract void takeDamage(int damage);
}
