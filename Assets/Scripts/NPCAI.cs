using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class NPCAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform targetTransform;
    private bool isTargetInSightRange,isTargetInAttackRange;

    public float timeBetweenAttack;
    public bool alreadyAttack;

    public Vector3 destinationPoint;
    public bool destinationPointSet;
    public float walkPointRange;

    public float sightRange, attackRange;

    [SerializeField] public GameObject sphere;

    public LayerMask player, ground;
    
    

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

       

    }

    private void Update()
    {
        isTargetInSightRange = Physics.CheckSphere(transform.position,sightRange,player);
        isTargetInAttackRange = Physics.CheckSphere(transform.position, attackRange,player);
        if (!isTargetInSightRange && !isTargetInAttackRange)
            Patroling();
        if (isTargetInSightRange && !isTargetInAttackRange)
            ChaseTarget();
        if (isTargetInAttackRange && isTargetInSightRange)
            Attack();
    }

    public void Patroling()
    {
        if (destinationPointSet)
        {
            _navMeshAgent.SetDestination(destinationPoint);
        }
        if(!destinationPointSet)
        {
            searchForDestinationPoint();
        }

        Vector3 distanceToDestinationPoint = transform.position - destinationPoint;
        if (distanceToDestinationPoint.magnitude < 1.0f)
        {
            destinationPointSet = false;
        }
    }

    public void ChaseTarget()
    {
        _navMeshAgent.SetDestination(targetTransform.position);
    }

    public void Attack()
    {
        _navMeshAgent.SetDestination(targetTransform.position);
        transform.LookAt(targetTransform);
        if (!alreadyAttack)
        {
            Rigidbody rb = Instantiate(sphere, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 25f,ForceMode.Impulse);
            rb.AddForce(transform.up * 7f,ForceMode.Impulse);
            alreadyAttack = true;
            Invoke("resetAttack",timeBetweenAttack);
        }
            
    }

    public void resetAttack()
    {
        alreadyAttack = false;
    }

    public void searchForDestinationPoint()
    {

        destinationPoint = new Vector3( transform.position.x + Random.Range(-walkPointRange, walkPointRange), transform.position.y, transform.position.z + Random.Range(-walkPointRange, walkPointRange));

        if (Physics.Raycast(destinationPoint, -transform.up,2.0f,ground))
        {
            destinationPointSet = true;
        }
    }

   
}
