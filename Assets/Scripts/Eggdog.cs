using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eggdog : MonoBehaviour
{
    [SerializeField] private float movePower;
    private Vector3 touchPosWorld;
    [SerializeField] private int timer;
    private bool isTouched;
    private bool isTimeout;
  

    // Start is called before the first frame update
    void Start()
    {
        touchPosWorld = Vector3.zero;
        isTouched = false;
        isTimeout = false;
        Invoke("Timeout", timer);
    }

    private void Awake()
    {
        this.gameObject.name += Time.deltaTime;
    }

    void Update()
    {
        if (OnTouch3D() || isTimeout) 
        {
            var posName = GetPositionName();
            switch (posName) 
            {
                case "rightSide":
                    GetComponent<Rigidbody>().velocity = new Vector3(movePower, 0f, 0f);
                    break;
                case "leftSide":
                    GetComponent<Rigidbody>().velocity = new Vector3(-movePower, 0f, 0f);
                    break;
                case "underSide":
                    GetComponent<Rigidbody>().velocity = new Vector3(0f, -movePower, 0f);
                    break;
                case "upSide":
                    GetComponent<Rigidbody>().velocity = new Vector3(0f, movePower, 0f);
                    break;
                default:
                    Debug.Log("wrong value");
                    break;
            }
        }

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        bool onScreen = screenPoint.z > -0.5 && screenPoint.x > -0.5 && screenPoint.x < 1.5 && screenPoint.y > -0.5 && screenPoint.y < 1.5;
        if (!onScreen) 
        {
            if (!isTouched)
            {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            Destroy(this.gameObject);
        }
    }

    bool OnTouch3D() 
    {
        if (Input.touchCount == 0)
            return false;
        if (Input.GetTouch(0).phase != TouchPhase.Began)
            return false;

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);

        if (!Physics.Raycast(ray, out hit))
            return false;

        //Debug.Log(hit.transform.name);
        if (hit.collider == null)
            return false;

        GameObject touchedObject = hit.transform.gameObject;
        //Debug.Log(touchedObject.gameObject.name);
        //Debug.Log(this.gameObject.name);
        if (touchedObject.transform.name != this.gameObject.name)
            return false;

        isTouched = true;
        return true;
    }

    string GetPositionName() 
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

        if (screenPos.x < Screen.width / 2)
            return "leftSide";
        if (screenPos.x >= Screen.width / 2)
            return "rightSide";
        if (screenPos.y < Screen.height / 2)
            return "underSide";

        return "upSide";
    }

    void Timeout() 
    {
        isTimeout = true;
    }
}
