using UnityEngine;
using System.Collections;
using InControl;

public class MyCharacterActions : PlayerActionSet {

    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction LockOn;

    public MyCharacterActions()
    {
        LockOn = CreatePlayerAction("Lock-On");
    }

}
