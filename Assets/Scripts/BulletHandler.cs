using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{

    public bool collided = false;
    public GameObject shootPosition;
    public Transform bulletTransform;
    public GameObject turret;
    public bool docked = true;
    public int speed;
    public TurretHandler turretHandler;
    private bool topWallHit;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        topWallHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.collided == true || StateManager.playingAgain || topWallHit)
        {
            if (this.transform.position != TurretHandler.bulletSpawnPosition)
            {
                this.GetComponent<CircleCollider2D>().enabled = false;
                float step = speed * Time.deltaTime;
                //this.rb.transform.position = Vector2.MoveTowards(this.transform.position, originalPosition, step);
                this.transform.position = Vector3.MoveTowards(this.transform.position, TurretHandler.bulletSpawnPosition, step);
            }
            else if (this.transform.position == TurretHandler.bulletSpawnPosition)
            {

                this.GetComponent<CircleCollider2D>().enabled = true;
                // make force rto 0
                this.rb.velocity = new Vector2(0, 0);

                this.collided = false;
                this.docked = true;

                this.transform.rotation = this.shootPosition.transform.rotation;
                this.bulletTransform = this.transform;
                this.rb.velocity = new Vector3(0f, 0f, 0f);
                this.rb.freezeRotation = true;
                this.bulletTransform.parent = turret.transform;

                turretHandler.canShoot = true;
                StateManager.playingAgain = false;
                topWallHit = false;
            }
        }
        else
        {
            if (rb.velocity.x != 0.0 && rb.velocity.y != 0)
            {
                this.transform.up = rb.velocity;
            }
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            this.collided = true;
        }
        else if (col.gameObject.tag == "TopWall")
        {
            topWallHit = true;
        }
    }


}
