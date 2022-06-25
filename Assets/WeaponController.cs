using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject weapon;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "Player")
        {
            _collider.GetComponent<EquipmentManagement>().PickUpWeapon(weapon);
            Destroy(gameObject);
        }
    }

    
}
