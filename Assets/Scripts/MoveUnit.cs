using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveUnit : MonoBehaviour
{
    public float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    public float turnSpeed;
    public float speed;
    
    public float safeDist;
    public float jumpForce;
    public bool onGround = true;
    public float gravityModifier;
    

    Animator animator;
    private int attackIndex;
    int VelocityHash;
    public Transform player;
    private Rigidbody playerRB;
    public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        attackIndex = animator.GetLayerIndex("Attack");

        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        safeDist = Vector3.Distance(transform.position, enemy.transform.position);
        bool forwardInput = Input.GetKeyDown("w");
        bool runPressed = Input.GetKey("left shift");
        float sideInput = Input.GetAxisRaw("Horizontal");

        transform.Rotate(Vector3.up * sideInput * turnSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }

        if (safeDist > 3 && forwardInput && velocity < .15)
        {
            velocity += Time.deltaTime * acceleration;
            playerRB.AddForce(Vector3.forward * speed , ForceMode.Impulse);
        }
        else if(safeDist < 3 || !forwardInput && velocity > 0)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        if(!forwardInput && velocity < 0)
        {
            velocity = 0.0f;
        }
        animator.SetFloat(VelocityHash, velocity);




        OneHandedAttack();

        // Debug.DrawRay(transform.position, transform.forward * .5f, Color.red);
        // Ray myRay = new Ray(transform.position, transform.forward * .5f);
        // RaycastHit hit;

        //  if (Physics.Raycast(myRay, out hit) && enemy || safeDist <= 3 && enemy)  
        //  {
        //       SceneManager.LoadScene(2);
        // }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Eventually add collisions for battle scene encounters rather than Raycast above
        onGround = true;
       
    }

    public void OneHandedAttack()
    {
        if (Input.GetKey(KeyCode.G))
        {
            animator.SetLayerWeight(attackIndex, 1);
        }
        if(!Input.GetKey(KeyCode.G))
        {
            animator.SetLayerWeight(attackIndex, 0);
        }
    }

}
