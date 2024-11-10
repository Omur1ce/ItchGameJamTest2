using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform player; 
    public float startZoom = 2f;
    public float targetZoom = 10f; 
    public float zoomSpeed = 0.5f; 

    public Vector3 offset = new Vector3(0, 0, -10f);

    private Camera cam;
    private float currentZoom;

    void Start()
    {
        cam = GetComponent<Camera>();

        currentZoom = startZoom;
        cam.orthographicSize = currentZoom;
    }

    void LateUpdate()
    {
        if (player != null)
        {
           
            transform.position = player.position + offset;
        }

       
        if (currentZoom < targetZoom)
        {
            currentZoom += zoomSpeed * Time.deltaTime;
            if (cam.orthographic)
            {
                cam.orthographicSize = Mathf.Min(currentZoom, targetZoom); 
            }
        }
    }

    void Update()
    {
        if (currentZoom < targetZoom)
        {
            currentZoom += zoomSpeed * Time.deltaTime;
            cam.orthographicSize = Mathf.Min(currentZoom, targetZoom);
        }
    }
}
