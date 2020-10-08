using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StreptobacillusMoniliformis : Enemy
{
    //public GameObject sphere;
    public float speed;
    Vector3 dir1;
    Vector3 dir2;
    public GameObject follow;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 pos = this.gameObject.transform.position;
        float x = pos.x - 1.0f;
        float y = pos.y;
        float z = pos.z;
        Vector3 newPos;
        newPos = new Vector3(x, y, z);
        this.gameObject.transform.position = newPos;
        */
       
        // Move the hound closer to the hare
        Vector3 newPos = MoveSourceToDest(this.gameObject.transform.position, follow.transform.position, speed);
        this.gameObject.transform.position = newPos;

        // Move the hare away from the hound chasing it
        /*newPos = MoveSourceToDest(hare.transform.position, selected.transform.position, -0.005f);
        hare.transform.position = newPos;
        */
    }

    void movement(GameObject gameObject)
    {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;

        if (Input.GetKeyDown("w"))
        {
            x += 1.0f;
            print("W");
        }
        if (Input.GetKeyDown("s"))
        {
            x -= 1.0f;
            print("S");
        }
        if (Input.GetKeyDown("a"))
        {
            z += 1.0f;
        }
        if (Input.GetKeyDown("d"))
        {
            z -= 1.0f;
        }

        Vector3 newPos = new Vector3(x, y, z);
        gameObject.transform.position = newPos; 
    }

    void movementAI()
    {
        GameObject n = GameObject.Find("N");
        GameObject s = GameObject.Find("S");

        dir1 = this.gameObject.transform.position - n.transform.position;
        dir2 = this.gameObject.transform.position - s.transform.position;

        dir1 = dir1.normalized;
        dir2 = dir2.normalized;

        this.gameObject.transform.position -= dir1 * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "N.Wall")
        {
            this.gameObject.transform.position += dir1 * Time.deltaTime * speed;
            print("Collided With N. Wall");
            Debug.Log("Test");
        }
        else if (collision.gameObject.tag == "S.Wall")
        {
            this.gameObject.transform.position -= dir2 * Time.deltaTime * speed;
            print("Collided With S. Wall");
            Debug.Log("Test");
        }
    }

    private Vector3 MoveSourceToDest(Vector3 _source, Vector3 _dest, float _speed)
    {
        Vector3 dir = (_dest - _source).normalized;
        _source += (dir * _speed);
        return _source;
    }

}
