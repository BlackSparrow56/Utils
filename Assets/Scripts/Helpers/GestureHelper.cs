using System;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Managers;

namespace ESparrow.Utils.Helpers
{
    /// <summary>
    /// ������-�������� ��� ������ �������� �� ������.
    /// </summary>
    public class GestureHelper
    {
        public event Action<Vector2> OnTap;
        public event Action<Vector2> OnDoubleTap;

        public event Action<Vector2> OnTouch;
        public event Action<Vector2> OnTouchAndHold;

        public event Action<Vector2, Vector2> OnSwype;
        public event Action<Vector2, Vector2> OnFlick;
        public event Action<Vector2, Vector2> OnDrag;

        public event Action<Vector2, float> OnStretch;

        private const float MaxTouchesMagnitude = 5f; // ������������ ���������� ��� ����, ����� ����������������� ���.
        private const float TapDuration = 0.1f; // ����������������� �������.
        private const float BetweenDoubleTap = 0.1f; // ���������� ����� ��������� ��� ����������� �������� �������.
        private const float TouchDuration = 0.25f; // ����������������� ����.
        private const float TouchAndHoldDuration = 1f; // ����������������� ���� � ���������.

        private const float MaxSwypeDuration = 0.75f; // ������������ ����� ������. ���� 
        private const float MaxFlickDuration = 1.5f; // ������������ ����� �����.
        private const float MinSwypeLength = 25f; // ����������� ����� ������ � ��������.
        private const float MinFlickLength = 100f; // ����������� ����� �����. ��� �� � ��������.

        private readonly List<TouchInfo> _touches = new List<TouchInfo>();

        public GestureHelper()
        {
            UnityMessagesManager.Instance.UpdateHandler += Check;
        }

        ~GestureHelper()
        {
            UnityMessagesManager.Instance.UpdateHandler -= Check;
        }

        private void Check()
        {
            CheckTouches();
            CheckDrags();
            CheckStretching();
        }

        private void CheckTouches()
        {

        }

        private void CheckDrags()
        {

        }

        private void CheckStretching()
        {

        }

        private class TouchInfo
        {
            private readonly Touch _touch;
            private readonly float _appearenceTime;

            public Touch Touch => _touch;
            public float TimeSinceAppear => Time.time - _appearenceTime;

            public TouchInfo(Touch touch)
            {
                _touch = touch;
                _appearenceTime = Time.time;
            }
        }
    }
}
