using UnityEngine; 
    using System.Collections; 

    public class Mouserotate : MonoBehaviour { 

    public Rigidbody rb;
    public float strengthx= 2f;
    public float strengthy= 2f;
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;
    public GameObject Panel;
    public GameObject Earthcam;
    float rotX;
    float rotY;
    bool rotate;

        void OnMouseDrag()
        {
            rotate = true;
            Panel.SetActive(false);
            rotX = Input.GetAxis("Mouse X") * strengthx;
            rotY = Input.GetAxis("Mouse Y") * strengthy;
        }
        void OnMouseUp() 
        {
            rotate = false;
            if(!Earthcam.activeSelf)
            Panel.SetActive(true);
        }
    private void Update()
    { RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out hit)){

        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
    }
    void FixedUpdate()
    {
        if (rotate)
        {
            rb.AddTorque(-rotY, -rotX, 0);
        }
        else{
            rb.angularVelocity = new Vector3(0,0,0);
        }
    }
    }