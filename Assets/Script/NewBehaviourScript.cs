using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    int b;
    void Start()
    {
        b = /*UnityEngine.Random.Range(0, 11)*/3;
        string B = Convert.ToString(b, 2);
        Debug.Log(B);
    }

   
}
