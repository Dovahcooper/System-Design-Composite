using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : Ability
{
    Camera mainCam;

    bool waiting = false;

    float radius = 0.5f;

    Vector3 blinkPos;


    public float maxDist = 30f;
    public float blinkTime;
    public Animator blinkAnim;

    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(abilityKey))
        {
            waiting = true;
        }
        else if (Input.GetKeyUp(abilityKey))
        {
            Activate();
        }

        if (Input.GetKeyDown(cancelKey))
        {
            waiting = false;
        }

        if (waiting)
        {
            Aim();
        }
    }

    public override void Activate()
    {
        base.Activate();

        if(waiting)
        {
            StartCoroutine(BlinkAnimation(blinkTime));
        }
    }

    IEnumerator BlinkAnimation(float animTime)
    {
        waiting = false;
        blinkAnim.SetTrigger("StartBlink");

        yield return new WaitForSeconds(animTime);

        transform.position = blinkPos;
        blinkAnim.SetTrigger("EndBlink");
    }

    public void Aim()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hitInfo, maxDist))
        {
            blinkPos = hitInfo.point + hitInfo.normal * radius;
        }
        else
        {
            blinkPos = mainCam.transform.position + mainCam.transform.forward * maxDist;
        }
    }
}
