using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SetChildrenInCircle))]
public class SteleInstantiationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SetChildrenInCircle steleInstantiation = (SetChildrenInCircle) target;

        if (GUILayout.Button("Set Steles"))
        {
            steleInstantiation.SetStelesAroundAutel();
        }
    }
}