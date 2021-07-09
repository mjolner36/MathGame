using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTask : MonoBehaviour
{

    public static int number1,number2,true_answer;
    public static GameObject TextTask;
    

    // Start is called before the first frame update
    void Start()
    {
        TextTask = GameObject.FindWithTag("TextOfTask");
        CreatNumbersforTask();
    }

    public static void CreatNumbersforTask()
    {
        number1 = Random.Range(1,10);
        number2 = Random.Range(1, 10);
        true_answer = number1 * number2;
        ShowTask();
    }

    public static void ShowTask()
    {
        TextTask.GetComponent<Text>().text = number1 + "*" + number2 + "=?";
    }
    
}
