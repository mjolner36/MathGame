using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Sprite ClickUp, ClickDown;
    public static bool IsCheckAnswerCorrect, IsCheckAnswerFail;
    public GameObject EffectOnMouseDown,AudioOnClick;


    private void Start()
    {
        AudioOnClick = GameObject.FindGameObjectWithTag("Click");
    }
    private void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ClickDown;
        EffectAnimationOnMouseDown();
    }
    public void EffectAnimationOnMouseDown()
    {
        Instantiate(EffectOnMouseDown, transform.position, Quaternion.identity);
    }
    private void OnMouseUp()
    {
        AudioOnClick.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<SpriteRenderer>().sprite = ClickUp;
        switch (gameObject.name)
        {              
            case "1":
                ShowInputText.answer += "1";
                break;
            case "2":
                ShowInputText.answer += "2";
                break;
            case "3":
                ShowInputText.answer += "3";
                break;
            case "4":
                ShowInputText.answer += "4";
                break;
            case "5":
                ShowInputText.answer += "5";
                break;
            case "6":
                ShowInputText.answer += "6";
                break;
            case "7":
                ShowInputText.answer += "7";
                break;
            case "8":
                ShowInputText.answer += "8";
                break;
            case "9":
                ShowInputText.answer += "9";
                break;
            case "0":
                ShowInputText.answer += "0";
                break;
            case "Delete":
                if (ShowInputText.answer != null) // первое нажатие на удаление символа 
                    if (ShowInputText.answer.Length > 0) ShowInputText.answer = ShowInputText.answer.Remove(ShowInputText.answer.Length - 1);
                    else break;
                break;
            case "CheckAnswer":

                if (ShowInputText.answer == CreateTask.true_answer.ToString())
                {
                    CreateTask.CreatNumbersforTask();
                    IsCheckAnswerCorrect = true;
                    ShowInputText.answer = null;
                }

                else
                {
                    Debug.Log("Lose");
                    IsCheckAnswerFail = true;
                }
                break;


        }
        ShowInputText.ShowChanges();
    }
}
