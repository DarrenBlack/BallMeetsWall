using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTestScript : MonoBehaviour {

    public Camera gameCamera;
    public GameObject wall;
    public Transform startPosition;
    public float speed;
    bool frozen;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        frozen = true;
        ResetPosition();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && frozen)
        {
            frozen = false;
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit");
                MoveTowardsWall();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Debug.Log("Hit the wall probably");
            Invoke("ResetPosition", 2f);
        }
    }   

    void MoveTowardsWall()
    {
        rb.constraints = RigidbodyConstraints.None;
        //rb.AddForce((wall.transform.position - transform.position) * speed);
        rb.AddForce((GetRandomPositionOnWall() - transform.position) * speed);
    }

    public Vector3 GetRandomPositionOnWall()
    {
        Mesh planeMesh = wall.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;

        float minX = wall.transform.position.x - wall.transform.localScale.x * bounds.size.x * 0.5f;
        float minZ = wall.transform.position.z - wall.transform.localScale.z * bounds.size.z * 0.5f;
        float minY = wall.transform.position.y - wall.transform.localScale.y * bounds.size.y * 0.5f;

        Vector3 newVec = new Vector3(Random.Range(minZ, -minZ), Random.Range(minY, -minY), wall.transform.position.z);
        return newVec;
    }

    void ResetPosition()
    {
        transform.position = startPosition.position;
        frozen = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;       
    }
}
