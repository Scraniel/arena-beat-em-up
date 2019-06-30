using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public string ScorePrefix;
    
    private Text _scoreText;
    private int _scoreAmount;

    public static Score Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        _scoreAmount = 0;
        _scoreText.text = ScorePrefix + _scoreAmount;
    }

    // Adds to the score being displayed
    public void AddScore(int toAdd)
    {
        _scoreAmount += toAdd;
        _scoreText.text = ScorePrefix + _scoreAmount;
    }
}
