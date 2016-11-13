using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor
{
    public interface IDetectorFocus : IDetectorFocusInput, IDetectorFocusOutput
    {
    }

    public interface IDetectorFocusInput
    {
        void DownOnAnother();
        void DownOnEqual();
        void DownOut();
    }

    public interface IDetectorFocusAction
    {
        void NotifyFocusCurrentItem();
        void NotifyUnfocusPreviosItem();
    }

    public interface IDetectorFocusOutput
    {
        event EventHandler FocusCurrentItem;
        event EventHandler UnfocusPreviosItem;
    }

    public interface IDetectorFocusTransition
    {
        void ToOut();
        void ToFirst();
        void ToEqual();
        void ToChange();
    }
}
