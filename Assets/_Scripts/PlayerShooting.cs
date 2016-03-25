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

        // place the hero in the starting position
        this._spawn001();

    } // end Start

    // Update is called once per frame
    void Update()
    {

    } // end Update

    //void FixedUpdate()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        Instantiate(this.muzzleFlash, flashPoint.position, Quaternion.identity);

    //        RaycastHit hit; // stores information from the Ray;

    //        if (Physics.Raycast(this._transform.position, this._transform.forward, out hit, 50f))
    //        {

    //            if (hit.transform.gameObject.CompareTag("Barrel"))
    //            {
    //                Instantiate(this.explosion, hit.point, Quaternion.identity);
    //                Destroy(hit.transform.gameObject);
    //                this.gameController.ScoreValue += 100;
    //            }
    //            else
    //            {

    //                Instantiate(this.bulletImpact, hit.point, Quaternion.identity);
    //            }


    //        }


    //    } // end if
    //} // end FixedUpdate

    //void OnCollisionEnter(Collider other)
    //{
    //    // Collision with a Bear event handler, gives the player 10 points
    //    if (other.gameObject.CompareTag("Gold"))
    //    {
    //        Debug.Log("Gold!");
    //        //this._coinSound.Play();
    //        Destroy(other.gameObject);
    //        this._gameController.ScoreValue += 10;
    //    }

    //    // Falling off the platform event handler, takes away a life and respawns to start of game
    //    if (other.gameObject.CompareTag("Gutter"))
    //    {
    //        Transform playerTransform = other.gameObject.GetComponent<Transform>();
    //        //playerTransform.position = this.spawnPoint;
    //        Debug.Log("Lava!");
    //        //this._spawn001();
    //        //this._hurtSound.Play();
    //        this._gameController.LivesValue--;
    //    }

    //}

    void OnCollisionEnter(Collision other)
    {
        // Collision with a Bear event handler, gives the player 10 points
        if (other.gameObject.CompareTag("Gold"))
        {
            Debug.Log("Gold!");
            this._goldSound.Play();
            Destroy(other.gameObject);
            this._gameController.ScoreValue += 10;
        }

        // Falling off the platform event handler, takes away a life and respawns to start of game
        if (other.gameObject.CompareTag("Gutter"))
        {
            Debug.Log("Lava!");
            this._spawn001();
            this._hurtSound.Play();
            this._gameController.LivesValue--;
        }

    }

    // Private Methods

    // Spawns to start of game
    private void _spawn001()
    {
        this._transform.position = new Vector3(4.21f, 1.67f, -4.85f);
    }

}
