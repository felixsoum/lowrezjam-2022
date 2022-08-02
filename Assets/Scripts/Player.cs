using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    bool isAirLock;

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float xForce = 0;
        float yForce = 0;

        if (x != 0)
        {
            xForce = x * 500f * Time.fixedDeltaTime;
        }

        if (y > 0)
        {
            var hits = Physics2D.RaycastAll(transform.position, Vector2.down, 0.55f);
            bool isGrounded = false;
            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    continue;
                }
                isGrounded = true;
            }

            if (!isGrounded)
            {
                isAirLock = false;
            }

            if (isGrounded)
            {
                yForce = 30000f * Time.fixedDeltaTime;
                isAirLock = true;
            }
        }

        if (x != 0 || y != 0)
        {
            rb2D.AddForce(new Vector2(xForce, yForce));
        }
    }


}
