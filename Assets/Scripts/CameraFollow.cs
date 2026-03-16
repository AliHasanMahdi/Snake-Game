using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameOverUI gameOverUI;

    public Transform target;
    public Vector3 offset = new Vector3(0, 15, -10);
    public float smoothTime = 0.15f;

    private Vector3 currentVelocity = Vector3.zero;

    void OnCollisionEnter(Collision collision)
    {
        // Check for Wall
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
    void LateUpdate()
    {
        if (target == null) return;

        // 1. Calculate the ideal position
        Vector3 targetPosition = target.position + offset;

        // 2. Smoothly move the camera to that position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

        // 3. Make the camera look at the snake without snapping the rotation
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}

