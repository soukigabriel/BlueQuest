using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Behaviour variables")]
    [Tooltip("Where the player is going to spawn in the next change of scene")]
    public string nextSpawnPoint;
    [Tooltip("Define if the player have been already created in the game")]
    public static bool playerCreated;

    [Space]
    [Header("Movement variables")]
    [Tooltip("Store the user input")]
    Vector2 axis = Vector2.zero;
    [Tooltip("The movement speed of the player")]
    [SerializeField] float speed;
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    [Tooltip("Stores the movement direction of the player before he stops")]
    public Vector2 lastMovement = Vector2.zero;
    [Tooltip("Define wheter or not tha player is moving")]
    bool isMoving;
    [Tooltip("The Rigid Body of the character")]
    Rigidbody2D m_RigidBody;

    [Space]
    [Header("Animation variables")]
    [Tooltip("The animator of the player")]
    Animator m_Animator;
    [Tooltip("Parameter HorizontalVelovity of the animator")]
    int m_HashHorizontalVelocity;
    [Tooltip("Parameter VerticalVelocity of the animator")]
    int m_HashVerticalVelocity;
    [Tooltip("Parameter LastHorizontal of the animator")]
    int m_HashLastHorizontal;
    [Tooltip("Parameter LastVertical of the animator")]
    int m_HashLastVertical;
    [Tooltip("Parameter IsMoving of the animator")]
    int m_HashIsMoving;

    void Start()
    {
        if(!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        isMoving = false;
        m_RigidBody = gameObject.GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_HashHorizontalVelocity = Animator.StringToHash("HorizontalVelocity");
        m_HashVerticalVelocity = Animator.StringToHash("VerticalVelocity");
        m_HashLastHorizontal = Animator.StringToHash("LastHorizontal");
        m_HashLastVertical = Animator.StringToHash("LastVertical");
        m_HashIsMoving = Animator.StringToHash("IsMoving");
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //Store the input in the axis only if there is any. Otherwise axis is equal to zero.
        if(Mathf.Abs(Input.GetAxisRaw(HORIZONTAL)) > 0.5f || Mathf.Abs(Input.GetAxisRaw(VERTICAL)) > 0.5f)
        {
            isMoving = true;
            axis = new Vector2(Input.GetAxisRaw(HORIZONTAL), Input.GetAxisRaw(VERTICAL));
            lastMovement = axis;
        }
        else
        {
            isMoving = false;
            axis = Vector2.zero;
        }
        m_RigidBody.velocity = axis.normalized * speed * Time.fixedDeltaTime;
        //The values are always delivered to the animator 
        m_Animator.SetBool(m_HashIsMoving, isMoving);
        m_Animator.SetFloat(m_HashHorizontalVelocity, axis.x);
        m_Animator.SetFloat(m_HashVerticalVelocity, axis.y);
        m_Animator.SetFloat(m_HashLastHorizontal, lastMovement.x);
        m_Animator.SetFloat(m_HashLastVertical, lastMovement.y);
    }

}
