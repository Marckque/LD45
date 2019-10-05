using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Collections.Generic;

[Serializable]
public class PlayableAssetSetCurrentGameStateTo : PlayableAsset, ITimelineClipAsset
{
    [SerializeField]
    private BehaviourSetCurrentGameStateTo template = new BehaviourSetCurrentGameStateTo();

    public ClipCaps clipCaps { get { return ClipCaps.None; } }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<BehaviourSetCurrentGameStateTo>.Create(graph, template);
    }
}
