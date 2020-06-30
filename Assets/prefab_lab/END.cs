using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour
{

    private AudioSource _audio;

    [Header("Перетяни сюда музыку для END")]

    public AudioClip end; //касета
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            void PlayEND()
            {
                _audio.clip = end;
                _audio.Play();
            }
        }
    }

}
