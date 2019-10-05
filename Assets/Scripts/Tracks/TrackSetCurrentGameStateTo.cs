using UnityEngine;
using System.Collections;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Collections.Generic;

[TrackBindingType(typeof(OrchestratorFlow))]
[TrackClipType(typeof(PlayableAssetSetCurrentGameStateTo))]
public class TrackSetCurrentGameStateTo : TrackAsset
{
    
}