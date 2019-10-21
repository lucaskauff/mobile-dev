using UnityEngine;

public class TileEndBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("Time to wait before destroying")] float destroyTime = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameController>().SpawnNextTile(true);

            Destroy(transform.parent.gameObject, destroyTime);
        }
    }
}