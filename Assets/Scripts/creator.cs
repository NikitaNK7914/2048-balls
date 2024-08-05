using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creator : MonoBehaviour
{
    [SerializeField] private Transform tube;
    [SerializeField] private Transform _spawner;
    [SerializeField] private ball ballPrefab;
    [SerializeField] private collapseManager collapseManager;
    [SerializeField] private Pointer pointer;

    private ball ballInTube;
    public ball ballInSpawner;

    private void CreateBallInTube()
    {
        int ballLevel = Random.Range(0, 3);
        ballInTube = Instantiate(ballPrefab, tube.position, Quaternion.identity);
        ballInTube.Init(collapseManager);
        ballInTube.SetLevel(ballLevel);
        ballInTube.SetToTube();
    }

    private IEnumerator MoveToSpawner()
    {
        ballInTube.transform.parent = _spawner;
        for (float t = 0; t < 1f; t += Time.deltaTime / 0.25f)
        {
            ballInTube.transform.position = Vector3.Lerp(tube.position, _spawner.position, t);
            yield return null;
        }
        ballInTube.transform.localPosition = Vector3.zero;
        ballInSpawner = ballInTube;
        pointer.SetLevel(ballInTube.Level);
        ballInTube = null;
        CreateBallInTube();
    }
    private void Drop()
    {
        ballInSpawner.Drop();
        ballInSpawner = null;
        if (ballInTube) { StartCoroutine(MoveToSpawner()); };
    }
    void Start()
    {
        CreateBallInTube();
        StartCoroutine(MoveToSpawner());
    }

    void Update()
    {
        if (ballInSpawner)
        {
            if (Input.GetMouseButtonUp(0)) { Drop(); }
        }
    }
}
