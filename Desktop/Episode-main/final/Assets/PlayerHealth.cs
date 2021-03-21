using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    
    public bool isCorrect = false;
    public float health;
    //to use when we animating the health bar 
    public float lerpTimer;
    public float maxHealth=100f;
    //controls how quickyl the delay bar will catch up to the one we immediately set 
    public float chipSpeed=2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    // Start is called before the first frame update
    public void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void Update()      
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHelathUI();
        if (isCorrect)
        {
            RestoreHealth(Random.Range(5, 10));
        }
        if (!isCorrect) 
        TakeDamage(Random.Range(5, 10));
    }
    //public void Update2()
    //{
    //    health = Mathf.Clamp(health, 0, maxHealth);
    //    UpdateHelathUI();

    //}

    public void UpdateHelathUI()
    {//debug out health value 
        Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB>hFraction)
        {
            frontHealthBar.fillAmount=hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF< hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        health = health-damage;
        lerpTimer = 0f;

    }
    public void RestoreHealth(float healamount)
    {
        health = health + healamount;
        lerpTimer = 0f;

    }
}
