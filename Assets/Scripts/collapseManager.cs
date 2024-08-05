using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collapseManager : MonoBehaviour
{
    public void Collapse(ActiveItem BallA, ActiveItem BallB)
    {
        if (BallA.GetComponent<Dynamite>() is Dynamite)
        {
            BallB.Deactivate();
            StartCoroutine(CollapseProcess(BallB, BallA));
        }
        else if (BallB.GetComponent<Dynamite>() is Dynamite)
        {
            BallA.Deactivate();
            StartCoroutine(CollapseProcess(BallA, BallB));
        }
        else if (BallA.GetCurrentLifeTime() > BallB.GetCurrentLifeTime())
        {
            BallB.Deactivate();
            StartCoroutine(CollapseProcess(BallB, BallA));
        }
        else { BallA.Deactivate(); StartCoroutine(CollapseProcess(BallA, BallB)); }

    }
    private IEnumerator CollapseProcess(ActiveItem ballA, ActiveItem ballB)
    {
        Vector3 startPosition = ballA.transform.position;
        for (float t = 0; t < 1f; t += Time.deltaTime / 0.3f)
        {
            ballA.transform.position = Vector3.Lerp(startPosition, ballB.transform.position, t);
            yield return null;
        }
        Destroy(ballA.gameObject);
        ballB.DoEffect();
    }
    private void Awake()
    {
        ActiveItem[] activeItems = FindObjectsOfType<ActiveItem>();
        foreach (ActiveItem item in activeItems)
        {
            item.Init(this);
        }
    }

}
