using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapObjects : MonoBehaviour
{
    // Start is called before the first frame update

    // what we are replacing this gameobject with
    private GameObject _replacement_prefab;

    // the parent of this game object 
    public GameObject Replacement_Object_prefab;
     
    void Start()
    {
        _replacement_prefab = Replacement_Object_prefab; 
    }

    // Update is called once per frame
    void Update()
    {
        Swap();
    }
    // public method that will swap the gameobjects
    public void Swap() {
        GameObject replacement_instance = GameObject.Instantiate(_replacement_prefab);

        // sets the replaced gameobjects parent to the parent of the object this script is attached to
        replacement_instance.transform.SetParent(transform.parent);
        Destroy(gameObject);
        Debug.Log("SWAPPED");
    }

}
