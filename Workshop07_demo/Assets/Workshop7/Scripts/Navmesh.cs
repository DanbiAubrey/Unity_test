using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{

    public GameObject turret;
    public float turretRotSpeed;//4.0f;

    public float chaseRange;//35.0f;
    public float attackRangeStop;//20.0f

    private NavMeshAgent nav;

    private Rigidbody _rigidbody;

    protected Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();

        GameObject target = GameObject.FindGameObjectWithTag("End");
        targetTransform = target.transform;

        if (!targetTransform)
            print("Target doesn't exist.. Please add one with Tag named 'Target'");
    }

    // Update is called once per frame
    void Update()
    {
        if (turret)
        {
            Quaternion turretRotation = Quaternion.LookRotation(targetTransform.position - transform.position);
            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, turretRotation, Time.deltaTime * turretRotSpeed);
        }

        nav.SetDestination(targetTransform.position);
    }
}
