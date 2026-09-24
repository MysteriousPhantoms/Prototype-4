using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 lastPosition;

    void Update()
    {
        HandleMovement();

        // If night and player moved → restart
        if (!GameManager.instance.isDay)
        {
            if (transform.position != lastPosition)
            {
                GameManager.instance.RestartPlayer(gameObject);
            }
        }

        lastPosition = transform.position;
    }

    void HandleMovement()
    {
        Vector2 move = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) move.y += 1;
        if (Keyboard.current.sKey.isPressed) move.y -= 1;
        if (Keyboard.current.aKey.isPressed) move.x -= 1;
        if (Keyboard.current.dKey.isPressed) move.x += 1;

        transform.position += (Vector3)move.normalized * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FinishLine"))
        {
            GameManager.instance.ShowWinScreen();
        }
    }
}
