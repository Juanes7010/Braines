using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horizontalMove;
    [SerializeField] float verticalMove;
    [SerializeField] float playerSpeed;
    [SerializeField] Vector3 playerInput;
    [SerializeField] CharacterController player;
    [SerializeField] Vector3 movePlayer;
    [SerializeField] Camera mainCamera;
    [SerializeField] Vector3 camForward;
    [SerializeField] Vector3 camRight;
    [SerializeField] Vector3 velocidadVertical;
    [SerializeField] float gravedad = -9f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverJugadorEnPlano();
        AplicarGravedad();
    }

    void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void MoverJugadorEnPlano()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        CamDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        //player.transform.LookAt(player.transform.position + movePlayer);

        player.Move(movePlayer * playerSpeed * Time.deltaTime);
    }

    void AplicarGravedad()
    {
        velocidadVertical.y += gravedad * Time.deltaTime;
        player.Move(velocidadVertical * Time.deltaTime);

        if(player.isGrounded && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f;
        }
    }
}
