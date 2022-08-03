using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameButton smashButton;
    [SerializeField] GameObject handObject;

    Vector3 offsetToCamera;
    const float acceleration = 3f;
    float velocity;
    const float MaxSpeed = 4f;
    Vector3 originalHandLocalPos;

    private void Awake()
    {
        offsetToCamera = transform.position - cameraController.transform.position;
        smashButton.OnButtonDown += OnSmashButtonDown;
        originalHandLocalPos = handObject.transform.localPosition;
    }

    private void OnSmashButtonDown(bool isDown)
    {
        if (!isDown)
        {
            return;
        }
        handObject.transform.localPosition = originalHandLocalPos + Vector3.down * 1;
    }

    private void Update()
    {
        float direction = cameraController.transform.position.x + offsetToCamera.x - transform.position.x;

        if (Mathf.Abs(direction) > 0.01f)
        {
            velocity += Mathf.Sign(direction) * acceleration * Time.deltaTime;
            velocity = Mathf.Clamp(velocity, -MaxSpeed, MaxSpeed);
            transform.position += Vector3.right * velocity * Time.deltaTime;
            float bounce = Mathf.Abs(Mathf.Sin(Time.time * 10f)) * 0.1f;
            spriteRenderer.transform.localPosition = Vector3.up * bounce;
        }
        else
        {
            velocity *= 0.5f;
            spriteRenderer.transform.localPosition = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSmashButtonDown(true);
        }

        handObject.transform.localPosition = Vector3.Lerp(handObject.transform.localPosition, originalHandLocalPos, 5f * Time.deltaTime);
    }
}
