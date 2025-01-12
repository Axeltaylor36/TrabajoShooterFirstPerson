using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] private Slider staminaSlider;

    [SerializeField] private float maxStamina = 100;

    private float currentStamina;

    private float regenerateStaminaTime = 0.1f;

    private float regenerateAmount = 2;

    private float losingStaminaTime = 0.1f;

    private Coroutine myCoroutineLosing;

    private Coroutine myCoroutineRegenerate;


    private void Start()
    {
        currentStamina = maxStamina;

        staminaSlider.maxValue = maxStamina;

        staminaSlider.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount > 0)
        {
            if(myCoroutineLosing != null)
            {
                StopCoroutine(myCoroutineLosing);
            }

            myCoroutineLosing = StartCoroutine(LosingStamineCoroutine(amount));
            
            if(myCoroutineRegenerate != null)
            {
                StopCoroutine(myCoroutineRegenerate);
            }


            StartCoroutine(RegenerateStaminaCoroutine());

        }
        else
        {
            Debug.Log("No tenemos Stamina");
            FindObjectOfType<PlayerMovement>().isSprinting = false;
        }

    }

    private IEnumerator LosingStamineCoroutine(float amount) 
    {
        while(currentStamina > 0) 
        {
            currentStamina -= amount;

            staminaSlider.value = currentStamina;

            yield return new WaitForSeconds(losingStaminaTime);
        }

        myCoroutineLosing = null;

        FindObjectOfType<PlayerMovement>().isSprinting = false;

    }

    private IEnumerator RegenerateStaminaCoroutine()
    {

        yield return new WaitForSeconds(1);

        while (currentStamina < maxStamina)
        {
            currentStamina += regenerateAmount;

            staminaSlider.value = currentStamina;

            yield return new WaitForSeconds(regenerateStaminaTime);
        }

        myCoroutineRegenerate = null;

    }

}
