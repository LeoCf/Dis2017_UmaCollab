﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace umaCollabApp.Behaviours
{
    public class StarBehaviorReq : Behavior<View>
    {
        //two members: one the tap recognizer and the other a list of StarBehaviorReq objects
        TapGestureRecognizer tapRecognizer;
        static List<StarBehaviorReq> Behaviors = new List<StarBehaviorReq>();
        static Dictionary<string, List<StarBehaviorReq>> starGroups = new Dictionary<string, List<StarBehaviorReq>>();

        // creating the static readonly bindable property
        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create("Rating",
                typeof(int),
                typeof(StarBehaviorReq), default(int));

        // creating the public property that uses that bindable property
        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        // creating the static readonly bindable property and add an event handler (propertyChanged)
        public static readonly BindableProperty IsStarredProperty =
            BindableProperty.Create("IsStarred",
                typeof(bool),
                typeof(StarBehaviorReq),
                false,
                propertyChanged: OnIsStarredChanged);

        public bool IsStarred
        {
            get { return (bool)GetValue(IsStarredProperty); }
            set { SetValue(IsStarredProperty, value); }
        }

        // helper method
        protected override void OnAttachedTo(View bindable)
        {
            tapRecognizer = new TapGestureRecognizer();
            tapRecognizer.Tapped += OnTapRecognizerTapped;
            bindable.GestureRecognizers.Add(tapRecognizer);
        }

        //event handler: determine which stars to light up and which to turn off
        static void OnIsStarredChanged(BindableObject bindable, object oldValue, object newValue)
        {
            StarBehaviorReq StarBehaviorReq = (StarBehaviorReq)bindable;

            if ((bool)newValue)
            {
                List<StarBehaviorReq> behaviors = Behaviors;

                var done = false;
                int counter = 1;
                int position = 0;

                foreach (var behavior in behaviors)
                {
                    if (behavior != StarBehaviorReq && !done)
                    {
                        behavior.IsStarred = true;
                    }
                    else if (behavior == StarBehaviorReq)
                    {
                        done = true;
                        behavior.IsStarred = true;
                        position = counter;
                    }
                    else if (behavior != StarBehaviorReq && done)
                    {
                        behavior.IsStarred = false;
                    }

                    behavior.Rating = position;
                    ++counter;
                }
            }
        }

        // definition of StarBehaviorReq
        public StarBehaviorReq()
        {
            Behaviors.Add(this);
        }

        // clean up
        protected override void OnDetachingFrom(View bindable)
        {
            bindable.GestureRecognizers.Remove(tapRecognizer);
            tapRecognizer.Tapped -= OnTapRecognizerTapped;
        }

        void OnTapRecognizerTapped(object sender, EventArgs args)
        {
            IsStarred = false;
            IsStarred = true;
        }
    }
}
