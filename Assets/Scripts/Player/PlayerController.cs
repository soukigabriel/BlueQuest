using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Bahaviour variables
    public string nextSpawnPoint;
    public static bool playerCreated;

    //Movement variables
    Vector2 axis = Vector2.zero;
    [SerializeField] float speed;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    public Vector2 lastMovement = Vector2.zero;
    bool isMoving;
    Rigidbody2D m_RigidBody;


    //Animation variables
    Animator m_Animator;
    int m_HashHorizontalVelocity;
    int m_HashVerticalVelocity;
    int m_HashLastHorizontal;
    int m_HashLastVertical;
    int m_HashIsMoving;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
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
        m_Animator.SetBool(m_HashIsMoving, isMoving);
        m_Animator.SetFloat(m_HashHorizontalVelocity, axis.x);
        m_Animator.SetFloat(m_HashVerticalVelocity, axis.y);
        m_Animator.SetFloat(m_HashLastHorizontal, lastMovement.x);
        m_Animator.SetFloat(m_HashLastVertical, lastMovement.y);
    }

}
