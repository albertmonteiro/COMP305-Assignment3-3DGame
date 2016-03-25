using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    //PUBLIC MEMBER VARIABLES
    public GameController gameController;

    // PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Rigidbody _rigidBody;
    private AudioSource[] _audioSources;
    private AudioSource _hurtSound;
    private AudioSource _goldSound;
    private AudioSource _ohYeahSound;

    // Use this for initialization
    void Start()
    {
        this._transform = gameObject.GetComponent<Transform>();
        this._rigidBody = gameObject.GetComponent<Rigidbody>();
        this.gameController = GameObject.FindWithTag("GameController").GetComponent("GameController") as GameController;

        // Setup AudioSources
        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._goldSound = this._audioSources[1];
        this._hurtSound = this._audioSources[2];
        this._ohYeahSound = this._audioSources[3];

        // Spawn to start of game
        this._spawnPoint();

    } // end Start


    // Update is called once per frame
    void Update()
    {

    } // end Update
    

    void OnCollisionEnter(Collision other)
    {
        // Collision gold chest gives the player 10 points
        if (other.gameObject.CompareTag("Gold"))
        {
            Debug.Log("Gold!");
            this._goldSound.Play();
            Destroy(other.gameObject);
            this.gameController.ScoreValue += 10;
        }

        // Falling in the Lava takes away a life and respawns to start of game
        if (other.gameObject.CompareTag("Gutter"))
        {
            Debug.Log("Lava!");
            this._spawnPoint();
            this._hurtSound.Play();
            this.gameController.LivesValue--;
        }

        // Game over point
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Finish!");
            this._ohYeahSound.Play();
            gameController.endGame();
        }

    }

    // Private Methods
    // Spawns to start of game
    private void _spawnPoint()
    {
        this._transform.position = new Vector3(4.21f, 1.67f, -4.85f);
    }

}
