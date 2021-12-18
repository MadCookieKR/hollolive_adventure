using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface CommandConsumer
{
    public abstract void handleCommand(Command c);
}
