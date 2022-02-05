using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float _waitingTime;

    public bool IsFinished => _waitingTime <= 0;
    public float TimeRemaining => _waitingTime;

    public Timer (float waitingTime)
    {
        _waitingTime = waitingTime;
    }

    public void ReduceTime (float timePassed)
    {
        _waitingTime -= timePassed;
    }
}
