using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float maxSpeed;
    private float speed;

    private Collider[] hitColliders;
    private RaycastHit Hit;

    public float sightRange;
    public float detectionRange;

    public Rigidbody rb;
    public GameObject Target;

    private bool seePlayer;


    // Start is called before the first frame update
    void Start()
    {
        speed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // detect if player is in range

        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
            foreach (var HitCollider in hitColliders)
            {
                if(HitCollider.tag == "Player")
                {
                    Target = HitCollider.gameObject;
                    seePlayer = true;
                }
            }    
        }
        else
        {
            if(Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, sightRange))
            {
                if(Hit.collider.tag != "Player")
                {
                    seePlayer = false;
                }
                else
                {
                    // calculate direction

                    var Heading = Target.transform.position - transform.position;
                    var Distance = Heading.magnitude;
                    var Direction = Heading / Distance;

                    Vector3 Move = new Vector3(Direction.x * speed, 0, Direction.z * speed);
                    rb.velocity = Move;
                    transform.forward = Move;
                }
            }
        }
        
    }
}
