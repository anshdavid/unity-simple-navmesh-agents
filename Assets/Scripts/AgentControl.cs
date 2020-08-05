using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{
    private Transform Destination;
    private float Speed;
    private NavMeshAgent Agent;
    private Animator Anim;
    private GameObject[] ListDestination;


    private float distance;

    void Start()
    {
        this.Agent = this.GetComponent<NavMeshAgent>();
        this.Anim = GetComponentInChildren<Animator>();

        if (ListDestination == null)
        {
            ListDestination = GameObject.FindGameObjectsWithTag("Destination");
        }
        updateAgentParams();
        setDestination(this.Destination);
        setSpeed(this.Speed);
    }

    void Update()
    {
        if (Vector3.Distance(this.Agent.transform.position, this.Destination.transform.position) <= 3.0f)
        {
            updateAgentParams();
            setDestination(this.Destination);
            setSpeed(this.Speed);
        }
    }

    private Transform randomDestination()
    {
        int index = Random.Range(0, ListDestination.Length);
        return ListDestination[index].transform;
    }

    private void updateAgentParams()
    {
        this.Destination = randomDestination();
        this.Speed = Random.Range(2, 8);
        Anim.SetFloat("Speed", this.Speed);
        Debug.LogFormat("Dest: {0} Speed: {1}",
                        this.Destination.position,
                        this.Speed);

    }

    private void setDestination(Transform dest)
    {
        this.Agent.SetDestination(dest.position);
    }

    private void setSpeed(float speed)
    {
        this.Agent.speed = speed;
    }

}