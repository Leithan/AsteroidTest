using System.Collections;
using UnityEngine;

// Handle model data and input output of the player
public class PlayerModelView : BaseMovableBehaviour, IPlayerModelView
{
    public PlayerController PlayerController { get; set; }

    [SerializeField] private float rotationSpeed;

    public float rotationAngleSpeed
    {
        get { return rotationSpeed; }
        set { rotationSpeed = value; }
    }

    [SerializeField] private float forwardForce;

    public float ForwardForce
    {
        get { return forwardForce; }
        set { forwardForce = value; }
    }

    [SerializeField] private float dampingForce;

    public float DampingForce
    {
        get { return dampingForce; }
        set { dampingForce = value; }
    }

    [SerializeField] private float fireTimer;

    public float FireTimer
    {
        get { return fireTimer; }
        set { fireTimer = value; }
    }

    [SerializeField] private float maxSpeed;

    public float MaxSpeed
    {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }

    private IEnumerator Start()
    {
        Controller.Init();
        //make it invuln. for a couple sec to avoid instant death
        GetComponent<PolygonCollider2D>().enabled = false;
        yield return new WaitForSeconds(2.0f);
        GetComponent<PolygonCollider2D>().enabled = true;
    }

    public override void SetController(IController controller)
    {
        PlayerController = (PlayerController)controller;
        PlayerController.ModelView = this;
        Controller = PlayerController;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerController.OnRotationClicked(RotationDirection.Left);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerController.OnRotationClicked(RotationDirection.Right);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerController.OnThrustClicked();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            PlayerController.OnFire();
        }

        PlayerController.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController.OnCollision();
    }
}