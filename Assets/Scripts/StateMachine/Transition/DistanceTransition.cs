using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
  
    public override void Enable()
    {
    }

    private void Update()
    {
        NeedTransit = true;
    }
}
