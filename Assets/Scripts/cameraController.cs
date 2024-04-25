using UnityEngine;

public class cameraController : MonoBehaviour
{

    private float currentPosX;
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Camera cam; // Reference to the Camera component
    [SerializeField] private float orthographicSize = 10f; // Set your desired fixed zoom level here

    private float lookAhead;

    private void Start()
    {
        if (cam == null)
        {
            cam = GetComponent<Camera>(); // Ensure there's a reference to the Camera component
        }
        cam.orthographicSize = orthographicSize; // Set the orthographic size once on start
    }


    private void Update()
    {
        //Follow player
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
