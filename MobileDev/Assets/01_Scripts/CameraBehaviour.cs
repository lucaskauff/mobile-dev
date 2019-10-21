using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Header("Objects to serialize")]
    [SerializeField, Tooltip("What object should the camera follow")] Transform target;

    [Header("Serializable variables")]
    [SerializeField, Tooltip("Offset from camera to target")] public Vector3 offset = new Vector3(0, 3, -6);

    private void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }
}