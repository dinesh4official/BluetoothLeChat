using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace BluetoothLeChat.iOS.PlatformEffects
{
    [Preserve(AllMembers = true)]
    internal static class TouchCollector
    {
        #region Fields

        static Dictionary<UIView, GestureActionsContainer> Collection { get; } =
            new Dictionary<UIView, GestureActionsContainer>();

        #endregion

        #region Public Methods

        public static void Add(UIView view, Action<TouchGestureRecognizer.TouchArgs> action)
        {
            if (Collection.ContainsKey(view))
            {
                Collection[view].Actions.Add(action);
            }
            else
            {
                var gest = new TouchGestureRecognizer
                {
                    CancelsTouchesInView = false,
                    Delegate = new TouchGestureRecognizerDelegate(view)
                };

                gest.OnTouch += ActionActivator;

                Collection.Add(view,
                    new GestureActionsContainer
                    {
                        Recognizer = gest,
                        Actions = new List<Action<TouchGestureRecognizer.TouchArgs>> { action }
                    });
                view.AddGestureRecognizer(gest);
            }
        }

        public static void Delete(UIView view, Action<TouchGestureRecognizer.TouchArgs> action)
        {
            if (!Collection.ContainsKey(view)) { return; }

            var ci = Collection[view];
            ci.Actions.Remove(action);

            if (ci.Actions.Count != 0) { return; }

            view.RemoveGestureRecognizer(ci.Recognizer);
            Collection.Remove(view);
        }

        #endregion

        #region Private Methods

        static void ActionActivator(object sender, TouchGestureRecognizer.TouchArgs e)
        {
            var gest = (TouchGestureRecognizer)sender;
            if (!Collection.ContainsKey(gest.View)) { return; }

            var actions = Collection[gest.View].Actions.ToArray();
            foreach (var valueAction in actions)
            {
                valueAction?.Invoke(e);
            }
        }

        #endregion

        [Preserve(AllMembers = true)]
        class GestureActionsContainer
        {
            #region Properties

            public TouchGestureRecognizer Recognizer { get; set; }

            public List<Action<TouchGestureRecognizer.TouchArgs>> Actions { get; set; }

            #endregion
        }
    }
}
