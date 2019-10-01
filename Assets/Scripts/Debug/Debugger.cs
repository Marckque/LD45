using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Debugger : MonoBehaviour
{
    [Header("Time Management")]

    [Range(0f, 1f)]
    public float slowSpeed = 0.5f;
    [Range(1f, 10f)]
    public float fastSpeed = 2f;

    private void Update()
    {
        // SCENE MANAGEMENT
        // RELOAD
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SceneManager.LoadScene(0);
        }

        // TIME MANAGEMENT
        // FAST
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Time.timeScale = fastSpeed;
        }
        // SLOW
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Time.timeScale = slowSpeed;
        }
        // BACK TO NORMAL
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            Time.timeScale = 1f;
        }
    }
}