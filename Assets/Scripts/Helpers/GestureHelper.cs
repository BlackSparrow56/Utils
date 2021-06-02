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

        private const float TapDuration = 0.1f; // ����������������� �������.
        private const float BetweenDoubleTap = 0.1f; // ���������� ����� ��������� ��� ����������� �������� �������.
        private const float TouchDuration = 0.25f; // ����������������� ����.
        private const float TouchAndHoldDuration = 1f; // ����������������� ���� � ���������.
        private const float MinSwypeLength = 50f; // ����������� ����� ������ � ��������.
        private const float MinFlickLength = 150f; // ����������� ����� �����. ��� �� � ��������.

        public GestureHelper()
        {
            UnityMessagesManager.Instance.UpdateHandler += Check;
        }

        ~GestureHelper()
        {
            UnityMessagesManager.Instance.UpdateHandler -= Check;
        }

        // TODO:

        private void Check()
        {

        }

        private void CheckTap()
        {

        }
    }
}
