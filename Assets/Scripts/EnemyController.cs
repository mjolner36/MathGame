using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int EnemyHealth, Damage;
    public Animator EnemyAnimator;
    public GameObject EffectOnHit,HealthBar;
    public AudioSource WinAudio;


    private void Start()
    {
        HealthBar.GetComponent<HealthBar>().SetMaxHealth(EnemyHealth);
    }
    private void Update()
    {
        if (Buttons.IsCheckAnswerFail == true)
        {
            EnemyAnimator.SetBool("ClickAnswerFail", true);
            
        }
        if (Buttons.IsCheckAnswerCorrect == true)
        {          
            EnemyAnimator.SetBool("ClickAnswer", true);
        }
    }

    public void StopAttackAnimation()
    {
        EnemyAnimator.SetBool("ClickAnswerFail", false); //перестаем проигрывать анимацию удара
        Buttons.IsCheckAnswerFail = false;

    }

    public void StopHitAnimation()
    {
        EnemyHealth -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Damage;
        HealthBar.GetComponent<HealthBar>().SetHealth(EnemyHealth);
        EnemyAnimator.SetBool("ClickAnswer", false); //перестаем проигрывать анимацию ранения
        Buttons.IsCheckAnswerCorrect = false;
        
        EnemyAnimator.SetInteger("EnemyHealth", EnemyHealth);

    }

    public void EffectAnimationOnHIt()
    {
        Instantiate(EffectOnHit, transform.position, Quaternion.identity);
    }

    public void AudioOnHit()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void AudioWin()
    {
        WinAudio.Play();
    }
}
