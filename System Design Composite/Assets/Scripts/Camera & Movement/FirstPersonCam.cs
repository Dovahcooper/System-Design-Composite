using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    public Vector2 mouseInput;

    [Range(30f, 89f)]
    public float maxRotation;

    [Range(-89f, -30f)]
    public float minRotation;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        mouseInput = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeRotation();
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void ChangeRotation()
    {
        mouseInput.x -= Input.GetAxis("Mouse Y");
        mouseInput.y += Input.GetAxis("Mouse X");

        mouseInput.x = Mathf.Clamp(mouseInput.x, minRotation, maxRotation);

        transform.eulerAngles = new Vector3(mouseInput.x, mouseInput.y, 0f);
    }
}
