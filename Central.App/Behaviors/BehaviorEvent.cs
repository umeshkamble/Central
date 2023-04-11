﻿using System.Reflection;
using System.Windows.Input;

namespace Central.App.Behaviors
{
    public class BehaviorEvent : BehaviorBase<VisualElement>
    {
        Delegate eventHandler;
        public static readonly BindableProperty EventNameProperty = BindableProperty.Create("EventName", typeof(string), typeof(BehaviorEvent), null, propertyChanged: OnEventNameChanged);
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(BehaviorEvent), null);

        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            RegisterEvent(EventName);
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            DeregisterEvent(EventName);
            base.OnDetachingFrom(bindable);
        }
        static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (BehaviorEvent)bindable;

            if (behavior.AssociatedObject == null) return;

            string oldEventName = (string)oldValue;
            string newEventName = (string)newValue;

            behavior.DeregisterEvent(oldEventName);
            behavior.RegisterEvent(newEventName);
        }

        void RegisterEvent(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;

            EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);

            if (eventInfo == null)
                throw new ArgumentException(string.Format("BehaviorEvent: Can't register the '{0}' event.", EventName));

            MethodInfo methodInfo = typeof(BehaviorEvent).GetTypeInfo().GetDeclaredMethod("OnEvent");
            eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(AssociatedObject, eventHandler);
        }

        void DeregisterEvent(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || eventHandler == null)
                return;

            EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);

            if (eventInfo == null)
                throw new ArgumentException(string.Format("BehaviorEvent: Can't de-register the '{0}' event.", EventName));

            eventInfo.RemoveEventHandler(AssociatedObject, eventHandler);
            eventHandler = null;
        }

        void OnEvent(object sender, object eventArgs)
        {
            if (Command == null) return;

            object resolvedParameter;

            resolvedParameter = eventArgs;

            if (Command.CanExecute(resolvedParameter))
                Command.Execute(resolvedParameter);
        }

    }
}
