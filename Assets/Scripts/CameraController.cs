using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameButton leftButton;
    [SerializeField] GameButton rightButton;

    float gameButtonInput;

    private void Awake()
    {
        leftButton.OnButtonDown += OnLeftButtonDown;
        rightButton.OnButtonDown += OnRightButtonDown;
    }

    private void OnRightButtonDown(bool isDown)
    {
        gameButtonInput = isDown ? 1f : 0f;
    }

    private void OnLeftButtonDown(bool isDown)
    {
        gameButtonInput = isDown ? -1f : 0f;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (gameButtonInput != 0)
        {
            x = gameButtonInput;
        }

        transform.position += Vector3.right * x * Time.deltaTime * 5f;
    }
}
