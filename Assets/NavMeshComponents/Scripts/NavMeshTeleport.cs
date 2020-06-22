using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshTeleport : MonoBehaviour
{
    IEnumerator Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                yield return StartCoroutine(Teleport(agent));
            }
            agent.CompleteOffMeshLink();
            yield return null;
        }
    }

    IEnumerator Teleport(NavMeshAgent agent)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 endpos = data.endPos + Vector3.up * agent.baseOffset;
        agent.transform.position = endpos;
        yield return null;
    }
}
