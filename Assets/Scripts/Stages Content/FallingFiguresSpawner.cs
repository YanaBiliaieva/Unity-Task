using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingFiguresSpawner : MonoBehaviour
{
    private readonly string[] _agentPaths = {"Prefabs/FallingBox", "Prefabs/FallingCapsule", "Prefabs/FallingCylinder"};
    private const float FiguresCreationInterval = 1.5f;
    private const int SpawnLinesCount = 3;
    private Vector2[] _spawnPoints;
    private float _creationTime;
    public event Action ClearFigure;
    private ArrayList _figures = new ArrayList();

    void Start()
    {
        CreateSpawnPoints();
    }

    void Update()
    {
        if (_creationTime + FiguresCreationInterval <= Time.time)
        {
            SpawnFigure();
            _creationTime = Time.time;
        }
    }

    private void CreateSpawnPoints()
    {
        _spawnPoints = new Vector2[SpawnLinesCount];
        
        //divide the visible width to get distance between spawn points
        var spawnStep = Mathf.Abs(CameraHelper.clampMinX - CameraHelper.clampMaxX) / (SpawnLinesCount + 1);
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = new Vector2(CameraHelper.clampMinX + spawnStep * (i + 1),
                CameraHelper.topOffsetY);
        }
    }

    /// <summary>
    /// Creates random figure and positions it to random row
    /// </summary>
    private void SpawnFigure()
    {
        var randomAgentNumber = Random.Range(0, _agentPaths.Length);
        var randomSpawnPoint = Random.Range(0, SpawnLinesCount);

        var figure = Instantiate(Resources.Load(_agentPaths[randomAgentNumber])) as GameObject;

        if (figure)
        {
            figure.transform.position = _spawnPoints[randomSpawnPoint];
            //when we create figure, we add it to list of currently existing figures
            _figures.Add(figure);
            //the purpose of this list is to destroy all existing figures if we need to clear stage to load another one
            figure.GetComponent<FallingObjectHandler>().NotifyOnDestroyed += FigureDestroyed;
            //when the figure destroys itself, it notifies spawner to remove it from the list
            ClearFigure += () => { Destroy(figure); };
        }
    }

    private void FigureDestroyed(GameObject figure)
    {
        _figures.Remove(figure);
    }

    private void OnDestroy()
    {
        ClearFigure?.Invoke();
    }
}