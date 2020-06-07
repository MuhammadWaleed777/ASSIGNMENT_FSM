using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMyVision : MonoBehaviour
{

    public enum enmSensitivity
    {
        HIGH,
        LOW

    }

    public enmSensitivity Sensitivity = enmSensitivity.HIGH;
    public bool targetInSight = false;
    public float fieldOfVision = 90f;
    public Transform target = null;
    public Transform Range = null;
    public Transform npcTransform = null;
    public SphereCollider sphereCollider = null;
    public Vector3 lastKnownSighting = Vector3.zero;

    public void Awake()
    {
        npcTransform = GetComponent<Transform>();
        sphereCollider = GetComponent<SphereCollider>();
        lastKnownSighting = npcTransform.position;
        target = GameObject.FindGameObjectWithTag("Car").GetComponent<Transform>();
        Range = GameObject.FindGameObjectWithTag("Range").GetComponent<Transform>();

    }
    bool InMyFieldOfVision()
    {
        Vector3 dirToTarget = target.position - Range.position;

        float angle = Vector3.Angle(Range.forward, dirToTarget);

        if (angle <= fieldOfVision)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    bool ClearLineOfSight()
    {

        RaycastHit hit;
        if (Physics.Raycast(Range.position, (target.position - Range.position).normalized, out hit, sphereCollider.radius))
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    void UpdateSight()
    {
        switch (Sensitivity)
        {
            case enmSensitivity.HIGH:
                targetInSight = InMyFieldOfVision() && ClearLineOfSight();
                break;

            case enmSensitivity.LOW:
                targetInSight = InMyFieldOfVision() || ClearLineOfSight();
                break;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        UpdateSight();
        if (targetInSight)
        {
            lastKnownSighting = target.position;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (!(other.CompareTag("Car")))
            return;
        targetInSight = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
