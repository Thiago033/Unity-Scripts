using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Vector3 mousePos;

    private Camera mainCam;

    public GameObject bullet;
    public Transform bulletTransform;

    public bool canShoot;

    public float timer;
    public float timeBetweenFiring;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canShoot = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}