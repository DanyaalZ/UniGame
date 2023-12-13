using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public float MaxSpeed;
    private float Speed;

    private Collider[] hitColliders;
    private RaycastHit Hit;

    public float SightRange;
    public float DetectionRange;

    public Rigidbody rb;
    public GameObject Target;

    private bool SeePlayer;

    public float Damage;
    public float KOTime;

    private bool CanAttack;

    public float MaxHealth;
    private float CurrentHealth;
    public TMP_Text EnemyHealthText;
    public Transform EnemyHealthTextPosition;


    // Start is called before the first frame update
    void Start()
    {
        Speed = MaxSpeed;
        CurrentHealth = MaxHealth;
        UpdateHealthDisplay();

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

    }

    // Update is called once per frame
    void Update()
    {
        // detect if player is in range

        if (!SeePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, DetectionRange);
            foreach (var HitCollider in hitColliders)
            {
                if(HitCollider.tag == "Player")
                {
                    Target = HitCollider.gameObject;
                    SeePlayer = true;
                }
            }    
        }
        else
        {
            if(Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, SightRange))
            {
                if(Hit.collider.tag != "Player")
                {
                    SeePlayer = false;
                }
                else
                {
                    // calculate direction

                    var Heading = Target.transform.position - transform.position;
                    var Distance = Heading.magnitude;
                    var Direction = Heading / Distance;

                    Vector3 Move = new Vector3(Direction.x * Speed, 0, Direction.z * Speed);
                    rb.velocity = Move;
                    transform.forward = Move;
                }
            }
        }
        UpdateHealthDisplayPosition();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<Health>().TakeDamage(Damage);
            StartCoroutine(AttackDelay(KOTime));
        }
    }

    IEnumerator AttackDelay(float Delay)
    {
        Speed = 0;
        CanAttack = false;
        yield return new WaitForSeconds(Delay);
        Speed = MaxSpeed;
        CanAttack = true;
    }

    private void UpdateHealthDisplay()
    {
        if (EnemyHealthText != null)
        {
            EnemyHealthText.text = "Health: " + CurrentHealth.ToString();
        }
    }

    private void UpdateHealthDisplayPosition()
    {
        if (EnemyHealthText != null)
        {
            // Update the position of the health text
            EnemyHealthText.transform.position = EnemyHealthTextPosition.position;

            // Make the health text always face the camera
            EnemyHealthText.transform.rotation = Quaternion.LookRotation(EnemyHealthText.transform.position - Camera.main.transform.position);
        }
    }

}
