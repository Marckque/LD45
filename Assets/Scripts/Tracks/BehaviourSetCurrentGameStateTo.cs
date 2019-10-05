﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Collections.Generic;

[Serializable]
public class BehaviourSetCurrentGameStateTo : PlayableBehaviour
{
    [SerializeField]
    private FlowState newFlowState;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.ProcessFrame(playable, info, playerData);

        var orchestrator = playerData as OrchestratorFlow;
        if (orchestrator == null)
            return;

        orchestrator.SetCurrentStateTo(newFlowState);
    }
}
