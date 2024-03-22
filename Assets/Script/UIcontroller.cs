using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;


public class UIcontroller : MonoSingleton <UIcontroller>
{
    public TextMeshProUGUI ScoreTotal;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI LivesCounter;
    public GameObject ScoreS;
    public GameObject Lives;
    public GameObject Score;
    public GameObject Image;
    public GameObject Title;
    public GameObject Title2;
    public GameObject StartButton;
    public GameObject RetryButton;
    public HashSet<int> numbersList;
    [System.Serializable]
    public class SerializableHashSet<T>
    {
        public List<T> items;

        public SerializableHashSet(HashSet<T> hashSet)
        {
            items = new List<T>(hashSet);
        }

        public HashSet<T> ToHashSet()
        {
            return new HashSet<T>(items);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        numbersList = new HashSet<int>();
        LoadNumbersList();

    }

    // Update is called once per frame
    void Update()
    {
        string numeroStringa = GameController.Instance.totalscore.ToString();
        ScoreTotal.SetText("Score:"+ numeroStringa);
        string LIVES = GameController.Instance.Lives.ToString();
        LivesCounter.SetText("Lives :"+LIVES);

        List<int> sortedNumbers = numbersList.OrderByDescending(x => x).ToList();

        // Costruisci una stringa contenente i numeri ordinati
        string numbersString = "Scores\n";
        foreach (int number in sortedNumbers)
        {
            numbersString += number.ToString() + "\n";
        }
        scoreText.text = numbersString;
        SaveNumbersList();
    }
    private void SaveNumbersList()
    {
        SerializableHashSet<int> serializableNumbersList = new SerializableHashSet<int>(numbersList);
        string json = JsonUtility.ToJson(serializableNumbersList);
        PlayerPrefs.SetString("NumbersList", json);
        PlayerPrefs.Save();
    }

    private void LoadNumbersList()
    {
        if (PlayerPrefs.HasKey("NumbersList"))
        {
            string json = PlayerPrefs.GetString("NumbersList");
            SerializableHashSet<int> serializableNumbersList = JsonUtility.FromJson<SerializableHashSet<int>>(json);
            numbersList = serializableNumbersList.ToHashSet();
        }
    }

}
