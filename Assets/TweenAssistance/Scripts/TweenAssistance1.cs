using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itach.TweenAssistance
{
    public class TweenAssistance1 : MonoBehaviour
    {
        public bool isTest;

        public Vector3 usePosition;


        public bool activeOnAwake = false;

        public bool useScale = true;
        public bool useAlpha = true;

        public TweenPart2[] parts=new TweenPart2[1];

        private void Awake()
        {

        }

        /// <summary>
        /// 瞬時に閉じた状態に
        /// </summary>
        private void SetClose()
        {


        }

        [System.Serializable]
        public class TweenPart2
        {
            public float startAlpha;
        }
    }
}
