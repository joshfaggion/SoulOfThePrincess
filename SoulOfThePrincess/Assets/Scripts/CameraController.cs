using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, .5f, -10); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dif = player.transform.position - gameObject.transform.position + offset;
        gameObject.transform.position += dif / 10;
        
    }
}
