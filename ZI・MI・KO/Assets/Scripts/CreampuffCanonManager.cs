using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreampuffCanonManager : MonoBehaviour {

    public GameObject bullet;
    public float timeOut;
    private Transform target;
    private float timeElapsed;

    private Renderer CreampuffRenderer;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
        CreampuffRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 diff = target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.left, diff);
        if (CreampuffRenderer.isVisible)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= timeOut)
            {
                shot();
                timeElapsed = 0.0f;
            }
            
        }
	}

    void shot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    
}
