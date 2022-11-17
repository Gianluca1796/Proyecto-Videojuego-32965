using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearZombie : MonoBehaviour
{

    public GameObject zombie;
    public GameObject Candle;
    public AudioSource sound;
    public GameObject desactiveGameObject;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            zombie.SetActive(false);
            sound.Play();
            Candle.SetActive(true);
            StartCoroutine("desactive");
        }
    }

    IEnumerator desactive()
    {
        yield return new WaitForSeconds(7);
        Destroy(desactiveGameObject);
    }

}

