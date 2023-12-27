using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forback : MonoBehaviour
{
    public GameObject Starting;
    public GameObject End;
    public AudioSource click;

    public void forward(){
        click.Play();
        Starting.SetActive(false);
        End.SetActive(true);
    }
    
    public void backward(){
        click.Play();
        Starting.SetActive(true);
        End.SetActive(false);
    }
}
