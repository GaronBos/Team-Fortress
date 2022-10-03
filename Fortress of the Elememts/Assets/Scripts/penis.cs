using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class penis : MonoBehaviour
{

    //bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    // gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools

    bool shooting, readyToShoot, reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing
    public bool allowInvoke = true;


    private void Awake()
    {
        // make sure magazine is full

        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        //set ammo display, if exists
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }

    private void MyInput()
    {
        //check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //reloading automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft < 0) Reload();

        // shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // just a ray through the middle of your screen
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); // just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread 
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); // just add spread to the last direction
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        //instantiate muzzle flash if you have one
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //invoke resetshot function (if not already invoked)
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //if more than one bulletspertap make sure to repeatr shoot funciton
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
