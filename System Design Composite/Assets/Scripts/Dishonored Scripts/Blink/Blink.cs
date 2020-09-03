using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : Ability
{
    Camera mainCam;

    bool aiming = false;

    Vector3 blinkPos;

    public GameObject blinkSphere;

    public float maxDist = 10f;
    public float blinkTime;
    public Animator blinkAnim;

    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;

        abilityKey = KeyCode.Mouse1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(abilityKey))
        {
            aiming = true;
        }
        else if (Input.GetKeyUp(abilityKey))
        {
            Activate();
        }

        if (Input.GetKeyDown(cancelKey))
        {
            aiming = false;
        }

        if (aiming)
        {
            Aim();
        }

        blinkSphere.SetActive(aiming);
    }

    public override void Activate()
    {
        base.Activate();

        if(aiming)
        {
            StartCoroutine(BlinkAnimation(blinkTime));
        }
    }

    IEnumerator BlinkAnimation(float animTime)
    {
        aiming = false;
        blinkAnim.SetTrigger("StartBlink");

        yield return new WaitForSeconds(animTime);

        transform.position = blinkPos;
        blinkAnim.SetTrigger("EndBlink");
    }

    public void Aim()
    {
        RaycastHit hitInfo;
        LayerMask maskLayer = LayerMask.GetMask("Environment");
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hitInfo, maxDist, maskLayer))
        {
            float radius = GetComponent<CapsuleCollider>().radius;
            blinkPos = hitInfo.point + (hitInfo.normal * radius);
        }
        else
        {
            blinkPos = mainCam.transform.position + (mainCam.transform.forward * maxDist);
        }

        blinkSphere.transform.position = blinkPos;
    }
}
