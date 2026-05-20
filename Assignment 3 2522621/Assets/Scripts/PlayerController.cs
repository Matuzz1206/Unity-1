using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotationSpeed = 10f;
    public float jumpHeight = 2f;
    public float gravity = -20f;

    CharacterController controller;
    Vector3 velocity;
    Transform cam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(h, 0, v).normalized;

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;

        Vector3 move = Vector3.zero;

        if (inputDir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            move = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        }

        Vector3 finalMove = move.normalized * moveSpeed + new Vector3(0, velocity.y, 0);
        controller.Move(finalMove * Time.deltaTime);
    }

    public void AddExternalForce(Vector3 force)
    {
        velocity += force;
    }

    public void Respawn()
    {
        controller.enabled = false;
        transform.position = CheckpointManager.instance.lastCheckpoint;
        velocity = Vector3.zero;
        controller.enabled = true;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GlassTile tile = hit.collider.GetComponent<GlassTile>();
        if (tile != null && !tile.safe)
            Destroy(tile.gameObject);
    }
}