using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    

    public bool canMove = true;
    [SerializeField] private float moveSpeed = 3f;
    public LayerMask solidObjectLayer;
    [SerializeField] private bool isMoving;
    public Vector2 input;
    private Vector2 lastDirection;
    private RaycastHit2D Raycast_Up;
    private RaycastHit2D Raycast_Down;
    private RaycastHit2D Raycast_Rigth;
    private RaycastHit2D Raycast_Left;
    
    void Start()
    {
        
    }

    void Update()
    {   //Cria 4 raycasts
        Raycast_Up = Physics2D.Raycast(transform.position, Vector2.up, 1f, solidObjectLayer);
        Debug.DrawRay(transform.position, Vector2.up * 1f, Color.red);
        Raycast_Down = Physics2D.Raycast(transform.position, Vector2.down, 1f, solidObjectLayer);
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.blue);
        Raycast_Rigth = Physics2D.Raycast(transform.position, Vector2.right, 1f, solidObjectLayer);
        Debug.DrawRay(transform.position, Vector2.right * 1f, Color.green);
        Raycast_Left = Physics2D.Raycast(transform.position, Vector2.left, 1f, solidObjectLayer);
        Debug.DrawRay(transform.position, Vector2.left * 1f, Color.yellow);
        SetDirection();
        movePlayer();
    }

    private void SetDirection(){
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (input.x > 0 && Raycast_Rigth.collider == null) {
            SwitchMovement(1,0);
        } else if (input.x < 0 && Raycast_Left.collider == null) {
            SwitchMovement(-1,0);
        } else if (input.y > 0 && Raycast_Up.collider == null) {
            SwitchMovement(0,1);
        } else if (input.y < 0 && Raycast_Down.collider == null) {
            SwitchMovement(0,-1);
        }

    } 

    

    private void SwitchMovement(int x, int y){

        lastDirection.x = x;
        lastDirection.y = y;
        
        
    }

    IEnumerator Move(Vector3 targetPos)
    {

        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {   
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectLayer ) != null)
        {
            return false;
        }
        return true;
    }


    private void movePlayer(){
        if(!isMoving){
            if(lastDirection.x != 0) lastDirection.y = 0;

            if(lastDirection != Vector2.zero){
                var targetPos = transform.position;
                targetPos.x += lastDirection.x;
                targetPos.y += lastDirection.y;
                if(isWalkable(targetPos)){
                    StartCoroutine(Move(targetPos));
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Right_Portal" && !isMoving) 
        {
            this.transform.position = new Vector3( -0.5f, -0.5f, 0f);   
        }
        if( collision.gameObject.tag == "Left_Portal" && !isMoving){
            this.transform.position = new Vector3( 33.5f, -0.5f, 0f);   
        }
    }


}