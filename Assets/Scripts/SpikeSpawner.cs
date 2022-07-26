using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField]
    private Spike[] spikes;
    [SerializeField]
    private float activateX;
    [SerializeField]
    private float deactivateX;

    public void ActivateAll()
    {
        int count = Random.Range(1, spikes.Length);

        int[] numerics = RandomNumeris(spikes.Length, count);

        for(int i=0; i<numerics.Length; ++i)
        {
            spikes[numerics[i].onMove(activateX)];
        }
    }
    public void DeactivateAll()
    {
        for(int i=0; i<spikes.Length; ++i)
        {
            spikes[i].OnMove(deactivateX);
        }
    }
}
