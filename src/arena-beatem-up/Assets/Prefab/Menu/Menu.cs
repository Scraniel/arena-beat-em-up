using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject OptionsButton;
    public string GameSceneName;

    // Go to the game menu!
    public void OnStartPressed()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    // We don't have an options menu yet... So just throw that button somewhere random
    public void OnOptionsPressed()
    {
        int left = Random.Range(-1, 2);
        int up = Random.Range(-1, 2);

        OptionsButton.transform.position = new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), Camera.main.nearClipPlane + 15f);
    }

    // Exit the game
    public void OnQuitPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
