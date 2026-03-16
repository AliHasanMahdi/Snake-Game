using System.Collections.Generic;
using UnityEngine;


public class SnakeController : MonoBehaviour
{
    public GameOverUI gameOverUI;
    public float moveRate = 0.25f;
    float timer;

    public Transform bodyPrefab;

    List<Transform> body = new List<Transform>();

    Vector3 direction = Vector3.forward;

    void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector3.back)
            direction = Vector3.forward;

        if (Input.GetKeyDown(KeyCode.S) && direction != Vector3.forward)
            direction = Vector3.back;

        if (Input.GetKeyDown(KeyCode.A) && direction != Vector3.right)
            direction = Vector3.left;

        if (Input.GetKeyDown(KeyCode.D) && direction != Vector3.left)
            direction = Vector3.right;
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= moveRate)
        {
            timer = 0;
            Move();
        }
    }

    void Move()
    {
        Vector3 previousPosition = transform.position;

        transform.position += direction;

        transform.rotation = Quaternion.LookRotation(direction);

        foreach (var part in body)
        {
            Vector3 temp = part.position;
            part.position = previousPosition;
            previousPosition = temp;
        }
    }

    public void Grow()
    {
        Transform part = Instantiate(bodyPrefab);
        body.Add(part);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check for Wall OR Body
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }
            else
            {
                Debug.LogWarning("GameOverUI reference is missing on the SnakeHead!");
            }
        }
    }
}

