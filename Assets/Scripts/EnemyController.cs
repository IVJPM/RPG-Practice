using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float chaseDist;

    public Transform enemy;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        chaseDist = Vector3.Distance(transform.position, player.transform.position);

        if (chaseDist <= 10)
        {
            
        }
    }
}
