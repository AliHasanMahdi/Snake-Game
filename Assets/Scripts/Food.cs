using UnityEngine;

public class Food : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SnakeController snake = other.GetComponent<SnakeController>();

        if (snake != null)
        {
            snake.Grow();

            GameManager.instance.AddScore();

            transform.position = new Vector3(
                Random.Range(-9, 9),
                0.5f,
                Random.Range(-9, 9)
            );
        }
        else
        {
            Debug.LogError("GameManager instance is missing from the scene!");
        }
    }
}
