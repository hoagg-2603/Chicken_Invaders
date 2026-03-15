using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreControlller : MonoBehaviour
{
    [SerializeField] TMP_Text textScore;
    private int score;
    public static ScoreControlller instance;

    private void Awake()
    {
        instance = this;
    }

    public void GetScore(int score) 
    {
        this.score += score;
        textScore.text = "Score :" + this.score.ToString();
    }
}
