using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Itach.TweenAssistance
{
    public class TweenAssistance : MonoBehaviour
    {
        public enum ColorType { None, Alpha, Color }

        public bool inactiveOnAwake;

        // Color
        public bool haveColor;
        public ColorType useColor;
        public float startAlpha;
        public float endAlpha;
        public Color startColor;
        public Color endColor;
        public MaskableGraphic maskableGraphic;

        // Scale
        public bool useScale;
        public Vector3 startScale;
        public Vector3 endScale;

        // Position
        public bool usePosition;
        public Vector3 startPosition;
        public Vector3 endPosition;

        // Rotation
        public bool useRotation;
        public Vector3 startEulerAngles;
        public Vector3 endEulerAngles;

        /// <summary>
        /// Automatically inactive on completion of tween
        /// </summary>
        [HideInInspector] public bool autoInactiveOnComplete = true;

        private Tween colorTween;
        private Tween scaleTween;
        private Tween positionTween;
        private Tween rotationTween;

        private void Reset()
        {
            inactiveOnAwake = true;

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
            useScale = false;
            startScale = transform.localScale * 0.2f;
            endScale = transform.localScale;

            // Position
            usePosition = false;
            startPosition =
                endPosition = transform.localPosition;

            // Rotation
            useRotation = false;
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

        /// <summary>
        /// Run all tween animations
        /// </summary>
        /// <param name="startValue">Start value when start is 0 and end is 1</param>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        /// <param name="flag"></param>
        public void Animate(float startValue, float endValue, float duration, Ease ease = Ease.Linear, float delay = 0, TweenFlag flag = TweenFlag.All)
        {
            if (useColor != ColorType.None && (flag & TweenFlag.Color) != 0)
                AnimateColor(startValue, endValue, duration, ease, delay);

            if (useScale && (flag & TweenFlag.Scale) != 0)
                AnimateScale(startValue, endValue, duration, ease, delay);

            if (usePosition && (flag & TweenFlag.Position) != 0)
                AnimatePosition(startValue, endValue, duration, ease, delay);

            if (useRotation && (flag & TweenFlag.Rotation) != 0)
                AnimateRotation(startValue, endValue, duration, ease, delay);
        }

        /// <summary>
        /// Run all tween animations
        /// </summary>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        /// <param name="flag"></param>
        public void Animate(float endValue, float duration, Ease ease = Ease.Linear, float delay = 0, TweenFlag flag = TweenFlag.All)
        {
            if (useColor != ColorType.None && (flag & TweenFlag.Color) != 0)
                AnimateColor(endValue, duration, ease, delay);

            if (useScale && (flag & TweenFlag.Scale) != 0)
                AnimateScale(endValue, duration, ease, delay);

            if (usePosition && (flag & TweenFlag.Position) != 0)
                AnimatePosition(endValue, duration, ease, delay);

            if (useRotation && (flag & TweenFlag.Rotation) != 0)
                AnimateRotation(endValue, duration, ease, delay);
        }

        /// <summary>
        /// Run a color (or alpha) tween animation
        /// </summary>
        /// <param name="startValue">Start value when start is 0 and end is 1</param>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        public void AnimateColor(float startValue, float endValue, float duration, Ease ease = Ease.Linear, float delay = 0)
        {
            if (useColor == ColorType.None) return;
            ForceActive();

            switch (useColor)
            {
                case ColorType.Alpha:
                    maskableGraphic.color = new Color(
                        maskableGraphic.color.r,
                        maskableGraphic.color.g,
                        maskableGraphic.color.b,
                        GetAlphaLeap(startValue));
                    break;
                case ColorType.Color:
                    maskableGraphic.color = GetColorLeap(startValue);
                    break;
            }

            AnimateColor(endValue, duration, ease, delay);
        }

        /// <summary>
        /// Run a color (or alpha) tween animation
        /// </summary>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        public void AnimateColor(float endValue, float duration, Ease ease = Ease.Linear, float delay = 0)
        {
            if (useColor == ColorType.None) return;
            ForceActive();

            if(useColor != ColorType.None)
                colorTween?.Kill();

            switch (useColor)
            {
                case ColorType.Alpha:
                    colorTween = maskableGraphic.DOFade(GetAlphaLeap(endValue), duration).SetEase(ease).SetDelay(delay);
                    break;
                case ColorType.Color:
                    colorTween = maskableGraphic.DOColor(GetColorLeap(endValue), duration).SetEase(ease).SetDelay(delay);
                    break;
            }

            if (useColor != ColorType.None && endValue == 0)
                colorTween.OnComplete(() => ForceInactive());
        }

        /// <summary>
        /// Run a local scale tween animation
        /// </summary>
        /// <param name="startValue">Start value when start is 0 and end is 1</param>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        public void AnimateScale(float startValue, float endValue, float duration, Ease ease = Ease.Linear, float delay = 0)
        {
            if (!useScale) return;
            ForceActive();
            transform.localScale = GetScaleLeap(startValue);
            AnimateScale(endValue, duration, ease, delay);
        }

        /// <summary>
        /// Run a local scale tween animation
        /// </summary>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        public void AnimateScale(float endValue, float duration, Ease ease = Ease.Linear, float delay = 0)
        {
            if (!useScale) return;
            ForceActive();
            scaleTween?.Kill();
            scaleTween = transform.DOScale(GetScaleLeap(endValue), duration).SetEase(ease).SetDelay(delay);
            if (endValue == 0)
                scaleTween.OnComplete(() => ForceInactive());
        }

        /// <summary>
        /// Run a local position tween animation
        /// </summary>
        /// <param name="startValue">Start value when start is 0 and end is 1</param>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        public void AnimatePosition(float startValue,  float endValue, float duration, Ease ease = Ease.Linear, float delay = 0)
        {
            if (!usePosition) return;
            ForceActive();
            transform.localPosition = GetPositionLeap(startValue);
            AnimatePosition(endValue, duration, ease, delay);
        }

        /// <summary>
        /// Run a local position tween animation
        /// </summary>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        public void AnimatePosition(float endValue, float duration, Ease ease = Ease.Linear, float delay = 0)
        {
            if (!usePosition) return;
            ForceActive();
            positionTween?.Kill();
            positionTween = transform.DOLocalMove(GetPositionLeap(endValue), duration).SetEase(ease).SetDelay(delay);
            if (endValue == 0)
                positionTween.OnComplete(() => ForceInactive());
        }

        /// <summary>
        /// Run a local euler angles tween animation
        /// </summary>
        /// <param name="startValue">Start value when start is 0 and end is 1</param>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        public void AnimateRotation(float startValue,  float endValue, float duration, Ease ease = Ease.Linear, float delay = 0)
        {
            if (!useRotation) return;
            ForceActive();
            transform.localEulerAngles = GetEulerAnglesLeap(startValue);
            AnimateRotation(endValue, duration, ease, delay);
        }

        /// <summary>
        /// Run a local euler angles tween animation
        /// </summary>
        /// <param name="endValue">End value when start is 0 and end is 1</param>
        /// <param name="duration"></param>
        /// <param name="ease">DG.Tweening.Ease</param>
        /// <param name="delay"></param>
        public void AnimateRotation(float endValue, float duration, Ease ease = Ease.Linear, float delay = 0)
        {
            if (!useRotation) return;
            ForceActive();
            rotationTween?.Kill();
            rotationTween = transform.DOLocalRotate(GetEulerAnglesLeap(endValue), duration).SetEase(ease).SetDelay(delay);
            if (endValue == 0)
                rotationTween.OnComplete(() => ForceInactive());
        }

        /// <summary>
        /// Kill all tweens
        /// </summary>
        public void Kill()
        {
            colorTween?.Kill();
            scaleTween?.Kill();
            positionTween?.Kill();
            rotationTween?.Kill();
        }

        private void ForceActive()
        {
            inactiveOnAwake = false;

            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
        }
        private void ForceInactive()
        {
            if(autoInactiveOnComplete)
                gameObject.SetActive(false);
        }

        private float GetAlphaLeap(float value)
        {
            return Mathf.Lerp(startAlpha, endAlpha, value);
        }

        private Color GetColorLeap(float value)
        {
            return Color.Lerp(startColor, endColor, value);
        }

        private Vector3 GetScaleLeap(float value)
        {
            return Vector3.LerpUnclamped(startScale, endScale, value);
        }

        private Vector3 GetPositionLeap(float value)
        {
            return Vector3.LerpUnclamped(startPosition, endPosition, value);
        }

        private Vector3 GetEulerAnglesLeap(float value)
        {
            return Vector3.LerpUnclamped(startEulerAngles, endEulerAngles, value);
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

    }
}
