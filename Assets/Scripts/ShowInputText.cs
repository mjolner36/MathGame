using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class  ShowInputText : MonoBehaviour
{
    public static GameObject TextInput;
    public static string answer;

    private void Start()
    {
        TextInput = GameObject.FindWithTag("TextInput");
}
    public static void  ShowChanges()
    {
       TextInput.GetComponent<Text>().text = answer; 
    }
}
