using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMove : MonoBehaviour
{

    public bool canMove = true;
    [SerializeField] private float moveSpeed = 3f;
    public LayerMask solidObjectLayer;
    public LayerMask InteractableLayer;
    [SerializeField] private bool isMoving;
    public Vector2 input;
    private RaycastHit2D hit;
    public Vector2 rayDirection;
    public GameObject pressFText;

    private void Start(){
        rayDirection = Vector2.down;

    }
    

    private void Update()
    {
        AllPlayerMove();
        Interact();

    }















    private void AllPlayerMove(){
        if(canMove){
            hit = Physics2D.Raycast(transform.position, rayDirection, 0.75f, InteractableLayer);
            Debug.DrawRay(transform.position, rayDirection * 0.75f, Color.red);
            SwitchRayCast();
            movePlayer();
        }
    }










    private void Interact(){
        ShowPressF();

        if(Input.GetKeyDown(KeyCode.F) && ShowPressF()){
            Interactable ObjInteractable = hit.collider.GetComponent<Interactable>();
            ObjInteractable.Interact();
        }
    }



    private bool ShowPressF(){
        if(hit.collider != null){
            pressFText.SetActive(true);
            return true;
        }else{
            pressFText.SetActive(false);
            return false;
        }
    }

    private void SwitchRayCast(){
        if (input.x > 0) {
            rayDirection = Vector2.right;
        } else if (input.x < 0) {
            rayDirection = Vector2.left;
        } else if (input.y > 0) {
            rayDirection = Vector2.up;
        } else if (input.y < 0) {
            rayDirection = Vector2.down;
        }

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
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectLayer | InteractableLayer) != null)
        {
            return false;
        }
        return true;
    }


    private void movePlayer(){
        if(!isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input.x != 0) input.y = 0;

            if(input != Vector2.zero){
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                if(isWalkable(targetPos)){
                    StartCoroutine(Move(targetPos));
                }
            }
        }
    }
    
}
