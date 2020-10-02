/** 
* Last modified 02/10/2020
* By: Sharek Khan
*/

using UnityEngine;

public class CellArmour : MonoBehaviour
{
    public GameObject cellArmour;
    public float rotationSpeed = 80f;

    public int armourPoint = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the Cell Armour throught every frame
        cellArmour.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
