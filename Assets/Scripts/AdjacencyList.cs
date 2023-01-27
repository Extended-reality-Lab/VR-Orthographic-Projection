using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Diagnostics;
using System.Collections.Specialized;

public class AdjacencyList<T> : MonoBehaviour
{
    private List<List<T>> _vertexList = new List<List<T>>();
    private Dictionary<T, List<T>> _vertexDict = new Dictionary<T, List<T>>();

    public AdjacencyList(T rootVertexKey)
    {
        AddVertex(rootVertexKey);
    }

    public List<T> AddVertex(T key)
    {
        List<T> vertex = new List<T>();
        _vertexList.Add(vertex);
        _vertexDict.Add(key, vertex);

        return vertex;
    }

    public void AddEdge(T startKey, T endKey)
    {
        List<T> startVertex = _vertexDict.ContainsKey(startKey) ? _vertexDict[startKey] : null;
        List<T> endVertex = _vertexDict.ContainsKey(endKey) ? _vertexDict[endKey] : null;

        if (startVertex == null)
            throw new ArgumentException("Cannot create edge from a non-existent start vertex.");

        if (endVertex == null)
            endVertex = AddVertex(endKey);

        startVertex.Add(endKey);
        endVertex.Add(startKey);
    }

    public void RemoveVertex(T key)
    {
        List<T> vertex = _vertexDict[key];

        //First remove the edges / adjacency entries
        int vertexNumAdjacent = vertex.Count;
        for (int i = 0; i < vertexNumAdjacent; i++)
        {
            T neighbourVertexKey = vertex[i];
            RemoveEdge(key, neighbourVertexKey);
        }

        //Lastly remove the vertex / adj. list
        _vertexList.Remove(vertex);
        _vertexDict.Remove(key);
    }

    public void RemoveEdge(T startKey, T endKey)
    {
        ((List<T>)_vertexDict[startKey]).Remove(endKey);
        ((List<T>)_vertexDict[endKey]).Remove(startKey);
    }

    public bool Contains(T key)
    {
        return _vertexDict.ContainsKey(key);
    }

    public int VertexDegree(T key)
    {
        return _vertexDict[key].Count;
    }
}