using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transition
{
    public override void Enable()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            NeedTransit = true;
    }
}
