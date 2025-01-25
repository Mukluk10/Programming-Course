using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.VFX;

public class VFXSpawnPos : MonoBehaviour
{
    public List<Vector3> spawnGas = new List<Vector3>();
    public VisualEffect vfx;

    private GraphicsBuffer projectileBuffer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnGas.Count > 0)
        {
            TransformData[] bufferData = new TransformData[spawnGas.Count];
            projectileBuffer?.Release();
            projectileBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, spawnGas.Count, Marshal.SizeOf(typeof(TransformData)));
            for (int i = 0; i < spawnGas.Count; i++)
            {
                bufferData[i] = new TransformData(spawnGas[i], new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(-1, 1)));
            }
            projectileBuffer.SetData(bufferData);
            vfx.SetGraphicsBuffer("LaunchData", projectileBuffer);
            vfx.SendEvent("Launch");
            spawnGas.Clear();
        }
    }
}

[VFXType(VFXTypeAttribute.Usage.GraphicsBuffer)]
struct TransformData
{
    public Vector3 Position;
    public Vector3 Direction;

    public TransformData(Vector3 position, Vector3 direction)
    {
        Position = position;
        Direction = direction;
    }
}
