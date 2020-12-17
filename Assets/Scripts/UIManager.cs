using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum eUIEvent
{
    destroedShape,
    lostShape
}
public class UIManager : MonoBehaviour
{
    public int score = 0;
    public int winScore = 100;
    public int lost = 100;

    private GameObject scoreTxt, healthPointsTxt, endGameTxt, restBtn;
    static private UIManager S;
  
    void Awake()
    {
        scoreTxt = transform.Find("Score").gameObject;
        healthPointsTxt = transform.Find("HealthPoints").gameObject;
        endGameTxt = transform.Find("EndGame").gameObject;
        restBtn = transform.Find("RestartButton").gameObject;
        endGameTxt.SetActive(false);
        restBtn.SetActive(false);

        if (S == null)  S = this;
        else   Debug.LogError("ERROR: UIManager.Awake(): S is already set!");
    }

    
    static public void EVENT(eUIEvent evt)
    {
        try
        {
            S.Event(evt);
        }
        catch (System.NullReferenceException nre)
        {
            Debug.LogError("ScoreManager.EVENT(): called while S=null.\n" + nre);
        }
    }
    void Event(eUIEvent evt)
    {
        switch (evt)
        {
            case eUIEvent.destroedShape:
                score++;
                scoreTxt.GetComponent<Text>().text = "Score: " + score.ToString();
                scoreTxt.GetComponent<Animation>().Play("ScoreAnimation");
                if(score>= winScore)
                {
                    endGameTxt.SetActive(true);
                    restBtn.SetActive(true);
                    endGameTxt.GetComponent<Text>().text = "YOU WON";
                    Time.timeScale = 0;
                }
                break;
            case eUIEvent.lostShape:
                lost--;
                healthPointsTxt.GetComponent<Text>().text = lost.ToString();
                if (lost <= 0)
                {
                    endGameTxt.SetActive(true);
                    restBtn.SetActive(true);
                    endGameTxt.GetComponent<Text>().text = "YOU LOSE";
                    Time.timeScale = 0;
                }
                break;
        }
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
