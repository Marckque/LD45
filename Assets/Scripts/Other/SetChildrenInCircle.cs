using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChildrenInCircle : MonoBehaviour
{
    public bool forceLookAt;
    
    [Range(0f, 360f)]
    public float angleAmplitude = 360f;
    [Range(5f, 1000f)]
    public float amplitude;
    [Range(0f, 5f)]
    public float yOffset;
    private Transform[] children;

    [ExecuteInEditMode]
    public void SetStelesAroundAutel()
    {
        children = new Transform[transform.childCount];

        float x, z;
        Vector3 stelePosition = Vector3.zero;
        float incr = (angleAmplitude / children.Length) * Mathf.Deg2Rad;
        float theta = 0f;

        for (int i = 0; i < children.Length; i++)
        {
            x = (amplitude * Mathf.Sin(theta));
            z = (amplitude * Mathf.Cos(theta));

            stelePosition.x = x;
            stelePosition.y = yOffset;
            stelePosition.z = z;

            theta += incr;

            children[i] = transform.GetChild(i);
            children[i].transform.position = stelePosition;
            
            if (forceLookAt)
            {
                children[i].LookAt(transform.position);
            }
        }
    }
}