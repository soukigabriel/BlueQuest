using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 axis = Vector2.zero;
    [SerializeField] float speed;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    Vector2 lastMovement = Vector2.zero;
    bool isMoving;
    Rigidbody2D m_RigidBody;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        isMoving = false;
        m_RigidBody = gameObject.GetComponent<Rigidbody2D>();
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
    }
}
