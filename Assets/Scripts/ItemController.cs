using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemController : MonoBehaviour
{
    public GameObject menuObject1;
    public GameObject menuObject2;
    public GameObject menuObject3;

    //object rotation 
    [SerializeField]
    private InputAction pressed;
    [SerializeField]
    private InputAction axis;
    private float rotationSpeed = 0.3f;
    private Vector2 rotation;
    private bool rotateObject;
    private Transform camera;

    private void Awake()
    {
        // hide menu objects when loading
        menuObject1.SetActive(false);
        menuObject2.SetActive(false);
        menuObject3.SetActive(false);

        //Enabling rotation
        camera = Camera.main.transform;
        pressed.Enable();
        axis.Enable();
        pressed.performed += OnPressed;
        pressed.canceled += OnReleased;
        axis.performed += OnAxis;
    }

    private void OnPressed(InputAction.CallbackContext context)
    {
        StartCoroutine(ObjectRotator());
    }

    private void OnReleased(InputAction.CallbackContext context)
    {
        rotateObject = false;
    }

    private void OnAxis(InputAction.CallbackContext context)
    {
        rotation = context.ReadValue<Vector2>();
    }

    private IEnumerator ObjectRotator()
    {
        rotateObject = true;
        while (rotateObject)
        {
            //apply rotation
            rotation = rotation * rotationSpeed;    
            transform.Rotate(Vector3.up, rotation.x, Space.World);
            transform.Rotate(camera.right, rotation.y, Space.World);
            yield return null;
        }
    }

    private void OnDestroy()
    {
        pressed.Disable();
        axis.Disable();
    }

    void Start()
    {
        ShowMenuObject(MenuController.selectedItem);
    }

    public void ShowMenuObject(string itemName)
    {
        if (itemName == menuObject1.name)
        {
            menuObject1.SetActive(true);
            menuObject2.SetActive(false);
            menuObject3.SetActive(false);
        }
        else if (itemName == menuObject2.name)
        {
            menuObject2.SetActive(true);
            menuObject1.SetActive(false);
            menuObject3.SetActive(false);
        }
        else if (itemName == menuObject3.name)
        {
            menuObject3.SetActive(true);
            menuObject1.SetActive(false);
            menuObject2.SetActive(false);
        }
    }

}
