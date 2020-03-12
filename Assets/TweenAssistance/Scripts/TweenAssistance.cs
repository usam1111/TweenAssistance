using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Itach.TweenAssistance
{
    public class TweenAssistance : MonoBehaviour
    {
        public enum ColorType { None, Alpha, Color }

        public bool inactiveOnAwake = false;

        // Color
        public bool haveColor;
        public ColorType useColor;
        public float startAlpha;
        public float endAlpha;
        public Color startColor;
        public Color endColor;
        public MaskableGraphic maskableGraphic;

        // Scale
        public bool useScale = false;
        public Vector3 startScale;
        public Vector3 endScale;

        // Position
        public bool usePosition = false;
        public Vector3 startPosition;
        public Vector3 endPosition;

        // Rotation
        public bool useRotation = false;
        public Vector3 startEulerAngles;
        public Vector3 endEulerAngles;

        private void Reset()
        {
            // Color
            useColor = ColorType.None;
            startAlpha = 0f;
            endAlpha = 1f;
            maskableGraphic = GetComponent<MaskableGraphic>();
            if (maskableGraphic != null)
            {
                startColor =
                    endColor = maskableGraphic.color;
                haveColor = true;
            }
            else
                haveColor = false;


            // Scale
            startScale = Vector3.one * 0.3f;
            endScale = Vector3.one;

            // Position
            startPosition =
                endPosition = transform.localPosition;

            // Rotation
            startEulerAngles =
                endEulerAngles = transform.localEulerAngles;
        }



        private void Awake()
        {
            if (inactiveOnAwake)
                gameObject.SetActive(false);
            
            // Color
            switch (useColor)
            {
                case ColorType.Alpha:
                    maskableGraphic = GetComponent<MaskableGraphic>();
                    maskableGraphic.color = new Color(
                        maskableGraphic.color.r,
                        maskableGraphic.color.g,
                        maskableGraphic.color.b,
                        startAlpha);
                    break;
                case ColorType.Color:
                    maskableGraphic = GetComponent<MaskableGraphic>();
                    maskableGraphic.color = startColor;
                    break;
            }

            // Scale
            if (useScale)
                transform.localScale = startScale;

            // Position
            if (usePosition)
                transform.localPosition = startPosition;

            // Rotation
            if (useRotation)
                transform.localEulerAngles = startEulerAngles;
        }

        #region ContextMenu
        [ContextMenu("Input To Start Color")]
        private void InputStartColor()
        {
            if (haveColor)
            {
                startColor = GetComponent<MaskableGraphic>().color;
            }
        }
        
        [ContextMenu("Input To End Color")]
        private void InputEndColor()
        {
            if (haveColor)
            {
                endColor = GetComponent<MaskableGraphic>().color;
            }
        }

        [ContextMenu("Input To Start Scale")]
        private void InputStartScale()
        {
            startScale = transform.localScale;
        }

        [ContextMenu("Input To End Scale")]
        private void InputEndScale()
        {
            endScale = transform.localScale;
        }

        [ContextMenu("Input To Start Position")]
        private void InputStartPosition()
        {
            startPosition = transform.localPosition;
        }

        [ContextMenu("Input To End Position")]
        private void InputEndPosition()
        {
            endPosition = transform.localPosition;
        }

        [ContextMenu("Input To Start Rotation")]
        private void InputStartRotation()
        {
            startEulerAngles = transform.localEulerAngles;
        }

        [ContextMenu("Input To End Rotation")]
        private void InputEndRotation()
        {
            endEulerAngles = transform.localEulerAngles;
        }
        #endregion ContextMenu

        /*
        public void SetComponentColor(Color color)
        {
            if (haveColor)
            {
                maskableGraphic.color = color;
            }
        }
        */
    }
}
