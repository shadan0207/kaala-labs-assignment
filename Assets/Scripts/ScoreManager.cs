using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int itemTotal = 22;
    
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI itemLeft;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }
    public void MinusItem(int item)
    {
        itemTotal -= item;
        UpdateItemUI();
    }

     void UpdateItemUI()
    {
        if(itemLeft!= null)
        {
            itemLeft.text = "itemLeft:" + itemTotal.ToString();
        }
    }
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
}
