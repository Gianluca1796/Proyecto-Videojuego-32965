using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstText : MonoBehaviour
{
    string frase = "Los duelos son dificiles lo se, pero en este caso no lo senti tanto ya que mis abuelos no fueron tan cercanos a mi, no concurrian a las fiestas familiares ni esas cosas que los abuelos hacen, ya sabes, eran raros, extraños pero quien soy yo para juzgarlos. Hoy cumplo años y parece que de regalo me dejaron lo peor, debo ir a su casa a limpiar y a recolectar sus cosas ya que van a ponerla en venta, que horror. Como sea, tal vez asi pueda comprenderlos y me de cuenta que no eran tan extraños como pense, o tal vez si?";
    public Text texto;
    public AudioSource car;
    void Start()
    {
        StartCoroutine(Reloj());
        StartCoroutine(NextScene());
        StartCoroutine(CarSound());
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.07f);
        }
    }
    IEnumerator NextScene()
    {

        yield return new WaitForSeconds(42);
        SceneManager.LoadScene(2);

    }
        IEnumerator CarSound()
    {

        yield return new WaitForSeconds(39);
        car.Play();

    }
}
