using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    [Header("My components")]
    [SerializeField] Rigidbody myRb;

    [Header("Serializable variables")]
    [SerializeField, Tooltip("How fast the ball moves left/right"), Range(0, 10)] float dodgeSpeed = 5;
    [SerializeField, Tooltip("How fast the ball moves forward"), Range(0, 100)] float rollSpeed = 5;

    //Private
    float horizontalSpeed;

    private void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal") * dodgeSpeed;
        myRb.velocity = new Vector3(horizontalSpeed, 0, rollSpeed);
    }
}