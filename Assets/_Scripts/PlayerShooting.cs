using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{

    //PUBLIC MEMBER VARIABLES
    //public Transform flashPoint;
    //public GameObject muzzleFlash;
    //public GameObject bulletImpact;
    //public GameObject explosion;
    //public Transform _transform;
    public GameController _gameController;


    // PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Rigidbody _rigidBody;
    private AudioSource[] _audioSources;
    private AudioSource _hurtSound;
    private AudioSource _goldSound;
    private AudioSource _ohYeahSound;
    //private GameController _gameController;

    // Use this for initialization
    void Start()
    {
        this._transform = gameObject.GetComponent<Transform>();
        this._rigidBody = gameObject.GetComponent<Rigidbody>();
        this._gameController = GameObject.FindWithTag("GameController").GetComponent("GameController") as GameController;

        // Setup AudioSources
        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._goldSound = this._audioSources[1];
        this._hurtSound = this._audioSources[2];
        this._ohYeahSound = this._audioSources[3];

        // place the hero in the starting position
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
            this._gameController.ScoreValue += 10;
        }

        // Falling in the Lava takes away a life and respawns to start of game
        if (other.gameObject.CompareTag("Gutter"))
        {
            Debug.Log("Lava!");
            this._spawnPoint();
            this._hurtSound.Play();
            this._gameController.LivesValue--;
        }

        // Falling in the Lava takes away a life and respawns to start of game
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Finish!");
            this._ohYeahSound.Play();
        }

    }

    // Private Methods
    // Spawns to start of game
    private void _spawnPoint()
    {
        this._transform.position = new Vector3(4.21f, 1.67f, -4.85f);
    }

}
