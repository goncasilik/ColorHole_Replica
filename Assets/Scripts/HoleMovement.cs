﻿using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshCollider meshCollider;

    [SerializeField] Vector2 moveLimits;
    [SerializeField] float radius;
    [SerializeField] Transform holeCenter;

    [Space]
    [SerializeField] float moveSpeed;

    Mesh mesh;
    List<int> holeVerticesIndexes;
    List<Vector3> offsets;
    int holeVerticesCount;

    float x, y;
    Vector3 touch, targetPos;

    void Start()
    {
        Game.isMoving = false;
        Game.isGameover = false;

        holeVerticesIndexes = new List<int>();
        offsets = new List<Vector3>();

        mesh = meshFilter.mesh;

        FindHoleVertices();
    }

    void Update()
    {
        Game.isMoving = Input.GetMouseButton(0);

        if (!Game.isGameover && Game.isMoving)
        {
            MoveHole();
            UpdateHoleVerticesPosition();
        }
    }

    void MoveHole()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        touch = Vector3.Lerp(
            holeCenter.position, 
            holeCenter.position + new Vector3(x, 0f, y),
            moveSpeed * Time.deltaTime
        );

        targetPos = new Vector3(
            Mathf.Clamp(touch.x, -moveLimits.x, moveLimits.x),
            touch.y,
            Mathf.Clamp(touch.z, -moveLimits.y, moveLimits.y)
        );

        holeCenter.position = targetPos;
    }

    void UpdateHoleVerticesPosition()
    {
        Vector3[] vertices = mesh.vertices;
        
        for (int i = 0; i < holeVerticesCount; i++)
        {
            vertices[holeVerticesIndexes[i]] = holeCenter.position + offsets[i];
        }

        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }

    void FindHoleVertices()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);

            if (distance < radius)
            {
                holeVerticesIndexes.Add(i);
                offsets.Add(mesh.vertices[i] - holeCenter.position);
            }
        }

        holeVerticesCount = holeVerticesIndexes.Count;
    }
}
