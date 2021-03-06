﻿using UnityEngine;
using UnityEngine.AI;

public class ActionRelocation : BaseAction
{
    Vector3 _targetLoc;

    public ActionRelocation(Vector3 targetLocation)
    {
        _targetLoc = targetLocation;
    }

    public override void Do(Model m)
    {
        ModelChar mc = m as ModelChar;
        NavMeshAgent agent = m.GetComponent<NavMeshAgent>();
        agent.speed = mc.currentSpeed;
        agent.SetDestination(_targetLoc);
    }
}