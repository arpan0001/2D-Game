using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthcollector : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collectionSoundEffect.Play();
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
            collectionSoundEffect.Play();   
        }
    }
}
