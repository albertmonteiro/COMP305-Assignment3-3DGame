﻿using UnityEngine;
using System.Collections;

public class DeathPlaneController : MonoBehaviour {
    // Public Instance Variables
    public Transform spawnPoint;
    public GameController gameController;

    // Private Instance Variables
    private AudioSource _playerDead;

	// Use this for initialization
	void Start () {
        this._playerDead = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform playerTransform = other.gameObject.GetComponent<Transform>();

            playerTransform.position = this.spawnPoint.position;
            gameController.LivesValue -= 1;
            this._playerDead.Play();
        }
        Debug.Log(other.gameObject.tag);
    }
}
