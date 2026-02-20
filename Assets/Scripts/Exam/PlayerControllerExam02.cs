using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam02 : MonoBehaviour
{
    private readonly bool enableAutoFireMode;
        public float speed;
    public float zRange = 10;
    public GameObject projectilePrefab;

    private float verticalInput;
    private InputAction moveAction;
    private InputAction shootAction;
    private float nextFireTime = 0f;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = moveAction.ReadValue<Vector2>().y;
        if (enableAutoFireMode)
        {
            
            if (Time.time >= nextFireTime)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);

                float autoFireInterval = 0;
                nextFireTime = Time.time + autoFireInterval;
            }
        }

        else if (shootAction.triggered) 
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
