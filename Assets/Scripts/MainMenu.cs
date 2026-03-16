using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject startMenuPanel;

    void Awake()
    {
        // Freeze the game as soon as it loads
        Time.timeScale = 0;
        startMenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        // Unfreeze the game and hide the menu
        Time.timeScale = 1;
        startMenuPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Button Clicked!"); // This shows in the console to prove it works

        Application.Quit(); // This closes the actual game (after you build it)

        // This part only works inside the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}