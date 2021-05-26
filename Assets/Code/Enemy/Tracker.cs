﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tracker : MonoBehaviour
{
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    AudioSource audioSource;
    public AudioClip zombieWalkingSound;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        target = GameObject.Find("Player").transform;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = zombieWalkingSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }

    }
}
