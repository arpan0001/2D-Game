using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currenthealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] private AudioSource dieSoundEffect;
    //  private TriggerDeath Dead;

    private void Awake()
    {
        currenthealth = startingHealth;
        anim = GetComponent<Animator>();
        //Animator = GetComponent<Animator>();
        //Dead = GetComponent<TriggerDeath>();
    }
    public void TakeDamage(float damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage, 0, startingHealth);

        if (currenthealth > 0)
        {
            anim.SetTrigger("hurt");
            //Debug.Log("Care Full");
        }
        else
        {
            if (!dead)
            {
                dieSoundEffect.Play();  
                anim.SetTrigger("die");
                GetComponent<playermovement>().enabled = false;
                dead = true;
            }

        }
    }
    public void AddHealth(float health)
    {
        currenthealth = Mathf.Clamp(currenthealth + health, 0, startingHealth);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
