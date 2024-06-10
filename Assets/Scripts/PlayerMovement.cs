using UnityEngine;
using TMPro;
public class CameraController : MonoBehaviour
{
    public float moveSpeed = .5f;
    public float jumpSpeed = 6f;
    public float gravity = 10f;
    public float mouseSensitivity = 1f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public TextMeshProUGUI TriggerTest;
    private float pitch = 0f;
    private float yaw = 0f;
    EquipElements equip;
    bool isLantran;
    bool isAxe;
    public Animator AxeAnimation;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        equip = GetComponent<EquipElements>();  
       
    }

    void Update()
    {
        Move();
        Equip();
        
    }
    void Equip()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isLantran)
           {
             equip.Equiplantren();
           }
           else if(isAxe)
            {
                equip.EquipAxe();

            }

        }
    }
    private void Move()
    {
        if (controller.isGrounded)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 move = transform.forward * moveVertical + transform.right * moveHorizontal;
            moveDirection = move * moveSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        AxeAnimation.SetBool("IsWalk", true);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        float rotateHorizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        float rotateVertical = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += rotateHorizontal;
        pitch -= rotateVertical;

        pitch = Mathf.Clamp(pitch, -90f, 90f);


        transform.localEulerAngles = new Vector3(pitch, yaw, 0);
        /*if(controller.velocity == Vector3.zero)
        {
            AxeAnimation.SetBool("IsWalk", false);
        }*/
    }
 
    private void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag("LanternTrigger")&&!isLantran)
        {
            isLantran = true;
            TriggerTest.text = "Press E To Hold Lantren";
            TriggerTest.enabled = true;
        } 
        else if(other.CompareTag("AxeTrigger")&&!isAxe)
        {
            isAxe = true;
            TriggerTest.text = "Press E To Hold Axe";
            TriggerTest.enabled = true;
        }
    }
     private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("LanternTrigger") && equip.hasLantren)
        {
             TriggerTest.enabled = false;
        }
        else if (other.CompareTag("AxeTrigger") && equip.hasAxe)
        {
            TriggerTest.enabled = false;
        }
    } 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LanternTrigger"))
        {    
           
            TriggerTest.enabled = false;
        }
        else if (other.CompareTag("AxeTrigger"))
        {
             
             
            TriggerTest.enabled = false;
        }
    } 
}