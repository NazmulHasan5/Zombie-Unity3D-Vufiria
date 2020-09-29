using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManBehabior : MonoBehaviour
{
    public GameObject zombie;
    public GameObject human;
    Animator aniZombie, aniHuman;
    Transform transZombie, transHuman;

    bool zTrack, hTrack;

    private void Start()
    {
        aniZombie = zombie.GetComponentInChildren<Animator>();
        aniHuman = human.GetComponentInChildren<Animator>();
        transZombie = zombie.GetComponent<Transform>();
        transHuman = human.GetComponent<Transform>();
    }

    void Update()
    {
        
        if(zTrack && hTrack)
        {
            Vector3 zom = transHuman.position - transZombie.position;
            Quaternion zombieRotation = Quaternion.LookRotation(zom);
            
            transZombie.rotation = zombieRotation;

            transHuman.rotation = zombieRotation;


            aniZombie.Play("run");
            aniHuman.Play("run");
        }
        else
        {
            aniZombie.Play("idle");
            aniHuman.Play("idle");
        }
        
    }

    public void ZombieTracked()
    {
        zTrack = true;
    }
    public void ZombieLost()
    {
        zTrack = false;
    }

    public void HumanTracked()
    {
        hTrack = true;
    }
    public void HumanLost()
    {
        hTrack = false;
    }
}
