using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EquipmentManagement : MonoBehaviour
{
    
    public Transform player;
    public Transform rightHand;
  //  public GameObject[] weaponsPrefabs;
    public GameObject weaponPos;
    public GameObject weapon;
    //public int weaponIndex;
    

   

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   

   public void PickUpWeapon(GameObject _weapon)
    {
            Destroy(weapon);
            GameObject newAxe = Instantiate(_weapon, weaponPos.transform.position, weaponPos.transform.rotation);
            weapon = newAxe;
            weapon.transform.parent = weaponPos.transform;
            weapon.transform.localPosition = Vector3.zero;
        
    }
}
