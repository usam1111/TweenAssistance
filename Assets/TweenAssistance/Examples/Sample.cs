using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Itach.TweenAssistance;
using DG.Tweening;

public class Sample : MonoBehaviour
{

    [SerializeField] private TweenAssistance imageObj = default;
    [SerializeField] private TweenAssistance cubeObj = default;

    IEnumerator Start()
    {
        // Cubu In
        cubeObj.Animate(endValue: 1f, duration: 0.5f, ease: Ease.OutQuart);

        yield return new WaitForSeconds(1.0f);

        // Cubu Out
        cubeObj.Animate(0f, 0.5f, Ease.InQuart);

        yield return new WaitForSeconds(1.0f);

        // Image In
        imageObj.AnimateColor(1f, 0.5f, Ease.Linear);
        imageObj.AnimatePosition(1f, 0.5f, Ease.OutQuart);

        yield return new WaitForSeconds(1.0f);

        imageObj.AnimateRotation(1f, 0.5f, Ease.InOutQuad);

        yield return new WaitForSeconds(1.0f);

        // Image Out
        imageObj.AnimateColor(0f, 0.5f, Ease.Linear);
        imageObj.AnimatePosition(2f, 0.5f, Ease.InQuart);
    }
    
}
