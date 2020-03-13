using UnityEngine;
using UnityEditor;

namespace Itach.TweenAssistance
{
    [CustomEditor(typeof(TweenAssistance))]
    public class TweenAssistanceEditor : Editor
    {
        public readonly float btnW = 46;

        public override void OnInspectorGUI()
        {
            TweenAssistance ta = target as TweenAssistance;

            ta.inactiveOnAwake = EditorGUILayout.Toggle("Inactive On Awake", ta.inactiveOnAwake);

            // Color
            if (ta.haveColor)
            {
                ta.useColor = (TweenAssistance.ColorType)EditorGUILayout.EnumPopup("Use Color", ta.useColor);

                EditorGUI.indentLevel++;
                switch (ta.useColor)
                {
                    case TweenAssistance.ColorType.None:
                        break;
                    case TweenAssistance.ColorType.Alpha:
                        ta.startAlpha = EditorGUILayout.FloatField("Start Alpha", ta.startAlpha);
                        ta.endAlpha = EditorGUILayout.FloatField("End Alpha", ta.endAlpha);
                        break;
                    case TweenAssistance.ColorType.Color:
                        using (new EditorGUILayout.HorizontalScope())
                        {
                            ta.startColor = EditorGUILayout.ColorField("Start Color", ta.startColor);
                            if (GUILayout.Button("Apply", GUILayout.Width(btnW)))
                            {
                                if (ta.haveColor)
                                {
                                    ta.maskableGraphic.color = ta.startColor;
                                }
                            }
                        }
                        using (new EditorGUILayout.HorizontalScope())
                        {
                            ta.endColor = EditorGUILayout.ColorField("End Color", ta.endColor);
                            if (GUILayout.Button("Apply", GUILayout.Width(btnW)))
                            {
                                if (ta.haveColor)
                                {
                                    ta.maskableGraphic.color = ta.endColor;
                                }
                            }
                        }
                        break;
                }
                EditorGUI.indentLevel--;
            }


            // Scale
            ta.useScale = EditorGUILayout.Toggle("Use Scale", ta.useScale);

            if (ta.useScale)
            {
                EditorGUI.indentLevel++;

                using (new EditorGUILayout.HorizontalScope())
                {
                    ta.startScale = EditorGUILayout.Vector3Field("Start Scale", ta.startScale);
                    if (GUILayout.Button("Apply", GUILayout.Width(btnW)))
                    {
                        ta.transform.localScale = ta.startScale;
                    }
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    ta.endScale = EditorGUILayout.Vector3Field("End Scale", ta.endScale);
                    if (GUILayout.Button("Apply", GUILayout.Width(btnW)))
                    {
                        ta.transform.localScale = ta.endScale;
                    }
                }

                EditorGUI.indentLevel--;
            }

            // Position
            ta.usePosition = EditorGUILayout.Toggle("Use Position", ta.usePosition);

            if (ta.usePosition)
            {
                EditorGUI.indentLevel++;

                using (new EditorGUILayout.HorizontalScope())
                {
                    ta.startPosition = EditorGUILayout.Vector3Field("Start Position", ta.startPosition);
                    if (GUILayout.Button("Apply", GUILayout.Width(btnW)))
                    {
                        ta.transform.localPosition = ta.startPosition;
                    }
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    ta.endPosition = EditorGUILayout.Vector3Field("End Position", ta.endPosition);
                    if (GUILayout.Button("Apply", GUILayout.Width(btnW)))
                    {
                        ta.transform.localPosition = ta.endPosition;
                    }
                }

                EditorGUI.indentLevel--;
            }

            // Rotation
            ta.useRotation = EditorGUILayout.Toggle("Use Rotation", ta.useRotation);

            if (ta.useRotation)
            {
                EditorGUI.indentLevel++;

                using (new EditorGUILayout.HorizontalScope())
                {
                    ta.startEulerAngles = EditorGUILayout.Vector3Field("Start Rotation", ta.startEulerAngles);
                    if (GUILayout.Button("Apply", GUILayout.Width(btnW)))
                    {
                        ta.transform.localEulerAngles = ta.startEulerAngles;
                    }
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    ta.endEulerAngles = EditorGUILayout.Vector3Field("End Rotation", ta.endEulerAngles);
                    if (GUILayout.Button("Apply", GUILayout.Width(btnW)))
                    {
                        ta.transform.localEulerAngles = ta.endEulerAngles;
                    }
                }

                EditorGUI.indentLevel--;
            }
        }

    }
}
