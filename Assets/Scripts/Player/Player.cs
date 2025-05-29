using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Others")]
    
    public static Player instance;

    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private Animator anim;

    [Header("Float")]
    [SerializeField] private float speed;
    [SerializeField] private float mouseSensibility;

    [Header("Vector")]
    [SerializeField] private Vector2 mouseMovement;
    [SerializeField] private Vector2 keyboardCommand;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        Move();
        Camera();
    }

    private void Move()
    {
        keyboardCommand = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -keyboardCommand.x;
        Vector3 moveVertical = transform.right * keyboardCommand.y;

        rig.linearVelocity = (moveHorizontal + moveVertical) * speed;


        if (rig.linearVelocity.magnitude == 0)
        {
            anim.Play("player_walk");
        }
        else
        {
            anim.Play("player_idle");
        }
    }

    private void Camera()
    {
        mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 rotation = new Vector3(0, 0, -mouseMovement.x * mouseSensibility);
        transform.Rotate(rotation);
    }
}
