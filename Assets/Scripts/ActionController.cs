using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public static ActionController instance;
    public Transform controlPoint, endPoint;
    private Transform startPoint;
    public float duration = 2.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {

    }
    public void BezierCurve(Card target)
    {
        Vector3 startPointPosition = target.transform.position;
        StartCoroutine(corBezier(target, startPointPosition));
    }

    private IEnumerator corBezier(Card target, Vector3 startPointPosition)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / duration);
            Vector3 p4 = Vector3.Lerp(startPointPosition, controlPoint.position, t);
            Vector3 p5 = Vector3.Lerp(controlPoint.position, endPoint.position, t);
            target.transform.position = Vector3.Lerp(p4, p5, t);

            //Debug.Log(target.transform.position);
            yield return null;
        }

        target.DestroyCard();
    }
}
