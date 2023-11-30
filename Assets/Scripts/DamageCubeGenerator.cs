
using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DamageCubeGenerator : NetworkBehaviour
{

    [SerializeField] private GameObject prefab;


    [SerializeField] private float generationRadius;

    [SerializeField] private TMP_InputField inputField;
    
    public void Generate()
    {
        int count = int.Parse(inputField.text);
        
        if (IsServer)
        {
            GenerateObj(count);
        }
        else if(IsClient)
        {
            Debug.Log("Client pressed");
            GenerateServerRpc(count);
        }
        
        
        
    }
    [ServerRpc(RequireOwnership = false)]
    public void GenerateServerRpc(int count)
    {
        Debug.Log("ServerRpc generated");
        GenerateObj(count);
    }

    public void GenerateObj(int count)
    {
        
        for (int i = 0; i < count; i++)
        {
            Debug.Log("Generated");
            Vector2 randomPos = GetRandomPositionInsideCircle(generationRadius);
            Vector3 pos = new Vector3(randomPos.x, 0, randomPos.y) + transform.position;
            GameObject o = Instantiate(prefab, pos, Quaternion.identity);
            o.GetComponent<NetworkObject>().Spawn(true);
        }
        
    }

    public Vector2 GetRandomPositionInsideCircle(float circleRadius)
    {
        Vector2 point = Random.insideUnitCircle * circleRadius;
        return point;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, generationRadius);
    }
}
