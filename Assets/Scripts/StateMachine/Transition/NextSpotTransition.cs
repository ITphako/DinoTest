using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSpotTransition : Transition
{
    [SerializeField]private MoveState _nextPoint;

    public override void Enable()
    {
        _nextPoint.OnPointChanged += NextPointChanged;
    }

    private void OnDisable()
    {
        _nextPoint.OnPointChanged -= NextPointChanged;
    }
    private void Update()
    {
    }

    private void NextPointChanged()
    {
        _nextPoint.speed = 0;
        NeedTransit = true;
    }
}
