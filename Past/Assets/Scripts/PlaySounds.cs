using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public AudioSource Sounds;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Sounds.Play();

        }
        StartCoroutine("desactiveObject");
    }
    IEnumerator desactiveObject()
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
