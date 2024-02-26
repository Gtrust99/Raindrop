using TMPro;
using UnityEngine;

public class Drop1 : MonoBehaviour
{
    public TextMeshProUGUI Operation;
    public TextMeshProUGUI Result;
    public int RESULT;
    public  int result;
    string numberString;
    void Start()
    {
        NumberGenerator();

    }

    // Update is called once per frame
    void Update()
    {

        if(RESULT==result)
        {
            GameObject[] allObjects = FindObjectsOfType<GameObject>();

            // Distruggi tutti gli oggetti che hanno un componente CircleComponent
            foreach (GameObject obj in allObjects)
            {
                if (obj.GetComponent<CircleCollider2D>() != null)
                {
                    Destroy(obj);
                }
            }
            NumberGenerator();
        }
    

        Keyboard();

    }
    void NumberGenerator()
    {
        int a;
        int b;
        b = Random.Range(0,11);
        a = b+Random.Range(0,11);
        string A = a.ToString();
        string B = b.ToString();
        Operator(a,b);
    }

    void Operator(int i , int j)
    {
        int OP;
        OP = Random.Range(0,3);
        if(OP==0)
        {
            RESULT = i + j;
            Operation.SetText(i+"+"+j);
        }
        if (OP == 1)
        {
            RESULT = i - j;
            Operation.SetText(i + "-" + j);
        }
        if (OP == 2)
        {
            RESULT = i * j;
            Operation.SetText(i + "x" + j);
        }

    }
    void Keyboard()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            numberString += "0";
            Result.SetText(numberString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            numberString += "1";
            Result.SetText(numberString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            numberString += "2";
            Result.SetText(numberString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            numberString += "3";
            Result.SetText(numberString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            numberString += "4";
            Result.SetText(numberString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            numberString += "5";
            Result.SetText(numberString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            numberString += "6";
            Result.SetText(numberString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            numberString += "7";
            Result.SetText(numberString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            numberString += "8";
            Result.SetText(numberString);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            numberString += "9";
            Result.SetText(numberString);
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            result = int.Parse(numberString);
            Debug.Log("Number: " + result);
            numberString = ""; // Reset the number string
        }
    }
}
