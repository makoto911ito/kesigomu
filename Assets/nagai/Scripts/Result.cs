using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    private void Update()
    {
        if( == false)
        {
            Debug.Log("plyer1が勝った");
        }
        else if(this.gameObject == false)
        {
            Debug.Log("plyer2が勝った");
        }
        else
        {
            Debug.Log("引き分け");
        }
    }
}
