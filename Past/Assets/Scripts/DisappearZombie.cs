using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearZombie : MonoBehaviour
{

    public GameObject zombie;
    public GameObject Candle;
    public AudioSource sound;
    public GameObject desactiveGameObject;
    public Animator zombieAnim;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            zombieAnim.SetBool("isAngry", true);
            sound.Play();
            Candle.SetActive(true);
            StartCoroutine("desactive");
        }
    }

    IEnumerator desactive()
    {
        yield return new WaitForSeconds(3);
        zombie.SetActive(false);
        Destroy(desactiveGameObject);
    }

}

