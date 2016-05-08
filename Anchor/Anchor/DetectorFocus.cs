using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    /// <summary>
    /// Детектор фокусирования.
    /// </summary>
    public class DetectorFocus : IDetectorFocus, IDetectorFocusTransition, IDetectorFocusAction
    {
        public DetectorFocus()
        {
            _stateOut = new OutState(this, this);
            _stateFirst = new FirstState(this, this);
            _stateEquals = new EqualsState(this, this);
            _stateChange = new ChangeState(this, this);

            _stateCurrent = _stateOut;
        }

        public Boolean IsOutState { get { return _stateCurrent is OutState; } }
        public Boolean IsFirstState { get { return _stateCurrent is FirstState; } }
        public Boolean IsEqualState { get { return _stateCurrent is EqualsState; } }
        public Boolean IsChangeState { get { return _stateCurrent is ChangeState; } }

        private OutState _stateOut;
        private FirstState _stateFirst;
        private EqualsState _stateEquals;
        private ChangeState _stateChange;

        private FocusState _stateCurrent;

        public event EventHandler FocusCurrentItem;
        public event EventHandler UnfocusPreviosItem;

        public void DownOnAnother()
        {
            _stateCurrent.DownOnAnother();
        }
        public void DownOnEqual()
        {
            _stateCurrent.DownOnEqual();
        }
        public void DownOut()
        {
            _stateCurrent.DownOut();
        }

        public void ToOut()
        {
            _stateCurrent = _stateOut;
        }
        public void ToFirst()
        {
            _stateCurrent = _stateFirst;
        }
        public void ToEqual()
        {
            _stateCurrent = _stateEquals;
        }
        public void ToChange()
        {
            _stateCurrent = _stateChange;
        }

        public void NotifyFocusCurrentItem()
        {
            CallHandler(FocusCurrentItem);
        }
        public void NotifyUnfocusPreviosItem()
        {
            CallHandler(UnfocusPreviosItem);
        }

        private void CallHandler(EventHandler eventHandler)
        {
            var handler = eventHandler;
            if (handler != null)
            { handler(this, new EventArgs()); }
        }

        private abstract class FocusState : IDetectorFocusInput
        {
            protected FocusState(IDetectorFocusTransition transition, IDetectorFocusAction action)
            {
                _transition = transition;
                _action = action;
            }

            protected IDetectorFocusTransition _transition;
            protected IDetectorFocusAction _action;

            public virtual void DownOnAnother() { }
            public virtual void DownOnEqual() { }
            public virtual void DownOut() { }
        }

        private class OutState : FocusState
        {
            public OutState(IDetectorFocusTransition transition, IDetectorFocusAction action)
                : base(transition, action)
            { }

            public override void DownOnAnother()
            {
                base.DownOnAnother();
                _action.NotifyFocusCurrentItem();
                _transition.ToFirst();
            }
        }

        private class FirstState : FocusState
        {
            public FirstState(IDetectorFocusTransition transition, IDetectorFocusAction action)
                : base(transition, action)
            { }

            public override void DownOnAnother()
            {
                base.DownOnAnother();
                _action.NotifyUnfocusPreviosItem();
                _action.NotifyFocusCurrentItem();
                _transition.ToChange();
            }
            public override void DownOnEqual()
            {
                base.DownOnEqual();
                _transition.ToEqual();
            }
            public override void DownOut()
            {
                base.DownOut();
                _action.NotifyUnfocusPreviosItem();
                _transition.ToOut();
            }
        }

        private class EqualsState : FocusState
        {
            public EqualsState(IDetectorFocusTransition transition, IDetectorFocusAction action)
                : base(transition, action)
            { }

            public override void DownOnAnother()
            {
                base.DownOnAnother();
                _action.NotifyUnfocusPreviosItem();
                _action.NotifyFocusCurrentItem();
                _transition.ToChange();
            }
            public override void DownOut()
            {
                base.DownOut();
                _action.NotifyUnfocusPreviosItem();
                _transition.ToOut();
            }
        }

        private class ChangeState : FocusState
        {
            public ChangeState(IDetectorFocusTransition transition, IDetectorFocusAction action)
                : base(transition, action)
            { }

            public override void DownOnAnother()
            {
                base.DownOnAnother();
                _action.NotifyUnfocusPreviosItem();
                _action.NotifyFocusCurrentItem();
            }
            public override void DownOnEqual()
            {
                base.DownOnEqual();
                _transition.ToEqual();
            }
            public override void DownOut()
            {
                base.DownOut();
                _action.NotifyUnfocusPreviosItem();
                _transition.ToOut();
            }
        }
    }
}
