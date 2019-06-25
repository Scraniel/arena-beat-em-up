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
        float rWidth = Random.Range(0f, Screen.width);
        float rHeight = Random.Range(0f, Screen.height);

        OptionsButton.transform.position = new Vector3(rWidth, rHeight, Camera.main.nearClipPlane);
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
