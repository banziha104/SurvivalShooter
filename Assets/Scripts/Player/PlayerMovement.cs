using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;
    private int floorMask;
    private float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor"); // Floor 라는 레이어마스크를 가져옮
        anim = GetComponent<Animator>();        // 애니메이터를 가져옮
        playerRigidbody = GetComponent<Rigidbody>(); // 리지드바디를 가져
    }

    private void FixedUpdate() // 유니티가 스크립트에서 자동으로 호출하며 Pysic Update에 사용
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h,v);
        Turning();
        Animating(h,v);
    }

    void Move(float h, float v)
    {
        movement.Set(h,0f,v);
        movement = movement.normalized * speed * Time.deltaTime; // 델타타임은 Update의 호출시간, 이를 곱해줌으로써
        playerRigidbody.MovePosition(transform.position + movement); //캐릭터에 현위치에 이동한 값을 더해줌
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); //카메라에서 마우스포지션 까지 빛을쏨

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position; //포지션 저장
            playerToMouse.y = 0f;
            
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = ( h!= 0f || v != 0f);
        anim.SetBool("IsWalking",walking);
    }
}
