using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    public float distance { get; private set; } = 0f;
    public float fuel { get; private set; } = 0f;
    public int level { get; private set; } = 1;



    //Awake = appel une seule et unique fois lors du chargement de la scene
    //Start : a chaque activation / desactivation
    private void Awake()
    {
       if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetDistance(float dist)
    {
        distance = dist;
        //Debug.Log("Distane :" + distance);
    }
    public void SetFuel(float fuel) => this.fuel += fuel;
    public void SetLevel() => level++;

    public void Reset()
    {
        this.distance = 0f;
        this.fuel = 0f;
        this.level = 1;
    }
}
