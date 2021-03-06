using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private Transition[] _transitions;
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public Player Player { get; private set; }

    public void Enter(Rigidbody rigidbody, Animator animator)
    {
        if (enabled == false)
        {
            Rigidbody = rigidbody;
            Animator = animator;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}

