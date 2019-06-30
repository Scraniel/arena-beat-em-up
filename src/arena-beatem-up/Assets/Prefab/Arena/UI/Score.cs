using UnityEngine;
using UnityEngine.UI;

public class Score : Singleton<Score>
{
    public string ScorePrefix;
    
    private Text _scoreText;
    private int _scoreAmount;

    // Adds to the score being displayed
    public void AddScore(int toAdd)
    {
        _scoreAmount += toAdd;
        _scoreText.text = ScorePrefix + _scoreAmount;
    }

    protected override void OnInitialize()
    {
        _scoreText = GetComponent<Text>();
        _scoreAmount = 0;
        _scoreText.text = ScorePrefix + _scoreAmount;
    }
}
