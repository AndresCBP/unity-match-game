using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GUIManager : MonoBehaviour
{
    public TextMeshProUGUI movesText, scoreText;
    private int moveCounter;
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = "Score" + score;
        }
    }
    public int MoveCounter
    {
        get { return moveCounter; }
        set
        {
            moveCounter = value;
            movesText.text = "Moves: " + moveCounter;

            if(moveCounter <= 0)
            {
                moveCounter = 0;
                StartCoroutine(GamesOver());
            }
        }
    }
    public static GUIManager sharedInstance;
    void Start()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        score = 0;
        moveCounter = 30;
        movesText.text = "Moves: " + moveCounter;
        scoreText.text = "Score" + score;
    }
    private IEnumerator GamesOver()
    {
        yield return new WaitUntil(() => !BoardManager.sharedInstance.isShifting);
        yield return new WaitForSeconds(0.25f);
    }

}
