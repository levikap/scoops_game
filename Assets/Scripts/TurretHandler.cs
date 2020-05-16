using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretHandler : MonoBehaviour
{

    public Rigidbody2D rb;
    public float degrees;
    public BulletHandler bullet;
    public GameObject turret;
    // the empty game object where the bullet should be spawned
    public GameObject bulletSpawn;
    // the position of the bulletSpawn object
    public static Vector3 bulletSpawnPosition;
    // the bullet's rotation
    Quaternion bulletRotation;
    // the speed that the bullet will travel at
    public int speed;
    // the rotation of the turret when the bullet should be fired
    Vector3 turretRotation;
    // the transform component of the bullet
    public Transform bulletTransform;
    // can the turret be shot? True if hasn't been shot yet
    public bool canShoot;
    public GameObject gamePlay;
    public bool useTouch;

    // Start is called before the first frame update
    void Start()
    {
        // get the bullet's rigid body
        rb = bullet.GetComponent<Rigidbody2D>();
        // get the quaternion of the bullet so it's rotated correctly
        bulletRotation = bulletSpawn.transform.rotation;
        // get the initial turret rotation
        turretRotation = turret.transform.up;
        // when the scene is started, you can shoot
        canShoot = true;
        useTouch = true;
    }

    // Update is called once per frame
    void Update()
    {

        Boolean moving = false;

        Vector2 touchPos = new Vector2();

        if (!useTouch)
        {
            // For debugging purposes
            if (Input.GetKeyDown("space"))
            {
                // sets the bullet spawn position to be the position of the spawn object
                bulletSpawnPosition = bulletSpawn.transform.position;
                bullet.docked = false;
                // shooting is done, can't shoot again
                canShoot = false;
                // gets the rotation of the turret at the time space is called
                turretRotation = turret.transform.up;

                // get the rigidbody component of the bullet to add a speed
                rb = bullet.GetComponent<Rigidbody2D>();

                // removes the barrel-parent as a parent for the bullet, as it's 
                // now been fired and shouldn't rotate when the mouse is moved
                bulletTransform = bullet.transform;
                bulletTransform.parent = null;

                // add a force based on a determined speed value and the x and y 
                // components of the velocity
                rb.AddForce(new Vector2(turretRotation.x * speed,
                                        turretRotation.y * speed));

                bullet.transform.parent = gamePlay.transform;
            }
        } else
        {
            if (!IsPointerOverUIObject())
            {

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);


                    if (touch.phase == TouchPhase.Began)
                    {
                        touchPos = touch.position;
                    }


                    // if the user presses space, shoot the bullet
                    if (touch.phase == TouchPhase.Ended && canShoot == true && touch.position != touchPos)
                    {
                        moving = true;
                        // sets the bullet spawn position to be the position of the spawn object
                        bulletSpawnPosition = bulletSpawn.transform.position;

                        
                        // gets the rotation of the turret at the time space is called
                        turretRotation = turret.transform.up;

                        

                    } else if (touch.phase == TouchPhase.Ended && touch.position == touchPos)
                    {
                      
                        bullet.docked = false;
                        // shooting is done, can't shoot again
                        canShoot = false;
                        // get the rigidbody component of the bullet to add a speed
                        rb = bullet.GetComponent<Rigidbody2D>();

                        // removes the barrel-parent as a parent for the bullet, as it's 
                        // now been fired and shouldn't rotate when the mouse is moved
                        bulletTransform = bullet.transform;
                        bulletTransform.parent = null;

                        // add a force based on a determined speed value and the x and y 
                        // components of the velocity
                        rb.AddForce(new Vector2(turretRotation.x * speed,
                                                turretRotation.y * speed));
                        bullet.transform.parent = gamePlay.transform;
                        }
                    }
                }
            }


    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}
