using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepNpc : NpcBase, IInteractNpc
{
    //protected override void Awake()
    //{
    //    base.Awake();
    //}

    public void InteractNpc()
    {
        myDialogue.CheckStateDialogue(13, state);
    }
}
