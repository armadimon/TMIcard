using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ActionController : MonoBehaviour
{
    //public ActionController(Vector3 controlPosition, Vector3 endPostion)
    //{
    //    controlPointPostion = controlPosition;
    //    endPointPostion = endPostion;
    //}

    //public static ActionController instance;
    public Transform controlPoint, endPoint;
    Vector3 endPointPostion;
    Vector3 controlPointPostion;
    private Transform startPoint;
    public float duration = 1.0f;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}

    public static ActionController Create(Vector3 controlPosition, Vector3 endPosition)
    {
        GameObject obj = new GameObject("ActionController");

        ActionController controller = obj.AddComponent<ActionController>();
        controller.Initialize(controlPosition, endPosition);

        return (controller);
    }

    // 초기화 메서드 추가
    public void Initialize(Vector3 controlPosition, Vector3 endPosition)
    {
        controlPointPostion = controlPosition;
        endPointPostion = endPosition;
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
            Vector3 p4 = Vector3.Lerp(startPointPosition, controlPointPostion, t);
            Vector3 p5 = Vector3.Lerp(controlPointPostion, endPointPostion, t);
            target.transform.position = Vector3.Lerp(p4, p5, t);

            yield return null;
        }

        Destroy(gameObject);
    }
}
