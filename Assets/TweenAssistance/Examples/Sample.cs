using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Itach.TweenAssistance;
using DG.Tweening;

public class Sample : MonoBehaviour
{
    
    [SerializeField] private TweenAssistance imageObg;
    [SerializeField] private TweenAssistance cubeObj;


    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);

        // Cubu In
        cubeObj.Animate(1f, 0.5f, Ease.OutQuart);

        yield return new WaitForSeconds(1.0f);

        // Cubu Out
        cubeObj.Animate(0f, 0.5f, Ease.InQuart);

        yield return new WaitForSeconds(1.0f);

        // Image In
        imageObg.AnimateColor(1f, 0.5f, Ease.Linear);
        imageObg.AnimatePosition(1f, 0.5f, Ease.OutQuart);

        yield return new WaitForSeconds(1.0f);

        imageObg.AnimateRotation(1f, 0.5f, Ease.InOutQuad);

        yield return new WaitForSeconds(1.0f);

        // Image Out
        imageObg.AnimateColor(0f, 0.5f, Ease.Linear);
        imageObg.AnimatePosition(2f, 0.5f, Ease.InQuart);
    }
    
}
