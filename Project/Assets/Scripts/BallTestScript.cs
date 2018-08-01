using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTestScript : MonoBehaviour {

    public Camera gameCamera;
    public GameObject wall;
    public Transform startPosition;
    public GameManager gm;


    bool frozen;
    SphereCollider coll;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<SphereCollider>();
        frozen = true;
        //ResetPosition();
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

        if (frozen)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ScoreWall")
        {
            Debug.Log("Hit the wall");

            collision.gameObject.GetComponent<Kick>().Score();
            Invoke("ResetPosition", gm.ballReturnDelay);
        }
    }   

    void MoveTowardsWall()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce((GetRandomPositionOnWall() - transform.position) * gm.ballSpeed);
    }

    public Vector3 GetRandomPositionOnWall()
    {
        Mesh planeMesh = wall.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;
        
        float minZ = wall.transform.position.z - wall.transform.localScale.z * bounds.size.z * 0.5f;
        float minY = wall.transform.position.y - wall.transform.localScale.y * bounds.size.y * 0.5f;

        Vector3 newVec = new Vector3(Random.Range(minZ, -minZ), Random.Range(minY, -minY), wall.transform.position.z);
        return newVec;
    }

    void ResetPosition()
    {

        Debug.Log("resetting position");
        StartCoroutine(MoveToPosition(transform, startPosition.position, gm.ballReturnTime));
        rb.constraints = RigidbodyConstraints.FreezeAll;
        frozen = true;
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
}
