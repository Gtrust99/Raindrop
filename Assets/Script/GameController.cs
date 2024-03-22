using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton <GameController>
{
     public int normaldropScore;
     public int goldendropScore;
     public int totalscore;
     public int breakerscore=750;
     public int savedScore;
     public float limitA=0;
     public float limitB =9;
     public int Lives=3;
     bool start=false;
    // Start is called before the first frame update
    void Start()
    {
        UIcontroller.Instance.Lives.SetActive(false);
        UIcontroller.Instance.ScoreS.SetActive(false);
        UIcontroller.Instance.Score.SetActive(false);
        UIcontroller.Instance.Image.SetActive(false);
        UIcontroller.Instance.StartButton.SetActive(true);
        UIcontroller.Instance.RetryButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        totalscore = normaldropScore + goldendropScore;
        if(start==true)
        {
            Rain.Instance.Spawn();
        }
        if(Lives <=0)
        {

            UIcontroller.Instance.numbersList.Add(totalscore);
            UIcontroller.Instance.RetryButton.SetActive(true);
            UIcontroller.Instance.ScoreS.SetActive(true);
            UIcontroller.Instance.Image.SetActive(false);
            UIcontroller.Instance.Score.SetActive(false);
            UIcontroller.Instance.Lives.SetActive(false);
            Time.timeScale = 0f;
            GameObject[] allObjects = FindObjectsOfType<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                if (obj.GetComponent<CircleCollider2D>() != null)
                {

                    Destroy(obj);

                }
            }
            start = false;
            
        }
        PlayerPrefs.SetInt("PlayerScore", totalscore);
        savedScore = PlayerPrefs.GetInt("PlayerScore", 0); // Recupera il punteggio salvato con la chiave "PlayerScore", se non presente restituisce 0// Salva il punteggio con la chiave "PlayerScore"
    }
   public void StartGame()
    {
        start = true;
        UIcontroller.Instance.StartButton.SetActive(false);
        UIcontroller.Instance.Title.SetActive(false);
        UIcontroller.Instance.Title2.SetActive(false);
        UIcontroller.Instance.Lives.SetActive(true);
        UIcontroller.Instance.Score.SetActive(true);
        UIcontroller.Instance.Image.SetActive(true);
    }
    public void RetryGame()
    {
  
        totalscore = 0;
        normaldropScore = 0;
        goldendropScore = 0;
        limitA = 0;
        limitB = 9;
        Lives = 3;
        Rain.Instance.spawnInterval = 1;
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.GetComponent<CircleCollider2D>() != null)
            {

                Destroy(obj);

            }
        }
        Time.timeScale = 1f;
        start = true;
        Vector3 newScale = UIcontroller.Instance.Image.transform.localScale;
        newScale.y = 1.10f; // Imposta la scala desiderata sull'asse Y
        UIcontroller.Instance.Image.transform.localScale = newScale;
        UIcontroller.Instance.ScoreS.SetActive(false);
        UIcontroller.Instance.RetryButton.SetActive(false);
        UIcontroller.Instance.Lives.SetActive(true);
        UIcontroller.Instance.Score.SetActive(true);
        UIcontroller.Instance.Image.SetActive(true);
    }
}
