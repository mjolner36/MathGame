using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public Animator PlayerAnimator;
    public AudioSource LoseAudio;
    public int PlayerHealth,Damage;
    public GameObject TextOfTask, Dialogue_Cloud,EffectOnHit, HealthBar,Camera; // задача на доске, облако над героем Input

    private void Start()
    {
        HealthBar.GetComponent<HealthBar>().SetMaxHealth(PlayerHealth);
    }
    public void Update()
    {
        if (Buttons.IsCheckAnswerCorrect == true)
        {
            TextOfTask.SetActive(false);
            Dialogue_Cloud.SetActive(false);
            PlayerAnimator.SetBool("ClickAnswer", true);

        }
        if (Buttons.IsCheckAnswerFail== true)
        {           
            PlayerAnimator.SetBool("ClickAnswerFail", true);
        }
    }

    public void StopAttackAnimation()
    {   
        PlayerAnimator.SetBool("ClickAnswer", false); //перестаем проигрывать анимацию удара
        Buttons.IsCheckAnswerCorrect = false;       
        TextOfTask.SetActive(true);
        Dialogue_Cloud.SetActive(true);
    }

    public void StopHitAnimation()
    {
        PlayerHealth -= GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>().Damage;
        HealthBar.GetComponent<HealthBar>().SetHealth(PlayerHealth);
        PlayerAnimator.SetBool("ClickAnswerFail", false); //перестаем проигрывать анимацию ранения
        Buttons.IsCheckAnswerFail = false;
        gameObject.GetComponent<AudioSource>().Play();
        PlayerAnimator.SetInteger("PlayerHealth", PlayerHealth);
    }

    public void EffectAnimationOnHIt()
    {
        Instantiate(EffectOnHit, transform.position, Quaternion.identity);
    }

    public void AudioOnHit()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    
    public void AudioLose()
    {
        LoseAudio.Play();
    }

    public void ShakeCamera()
    {
        Camera.transform.DOShakePosition(0.5f, 0.5f, 8, 20, false, true);
    }

}
