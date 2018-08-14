using UnityEngine;
using System;
using System.Collections.Generic;

namespace ZW.MVCForUnity
{
    /// <summary>
    /// Facade
    /// </summary>
    public class Facade : IFacade
    {
        //protected IControllerManager m_controllerManager = null;
        //protected IViewManager m_viewManager = null;
        //protected IModelManager m_modelManager = null;

        protected Dictionary<string, IList<IEventObserver>> m_eventObserverList = new Dictionary<string, IList<IEventObserver>>();

        public Dictionary<string, IList<IEventObserver>> EventHandlerList
        {
            get
            {
                return m_eventObserverList;
            }
        }

        private static IFacade Instance = null;

        public static IFacade GetInstance()
        {
            if (Instance == null)
                Instance = new Facade();

            return Instance;
        }

        public Facade()
        {
            //InitializeFacade();
        }

		protected virtual void InitializeFacade()
        {
            //m_modelManager = ModelManager.GetInstance();
            //m_viewManager = ViewManager.GetInstance();
            //m_controllerManager = ControllerManager.GetInstance();
        }

        public bool HasCommand(string eventName)
        {
            return ControllerManager.GetInstance().HasCommand(eventName);
        }

        public void RegisterCommand(string eventName, Func<ICommand> command)
        {
            ControllerManager.GetInstance().RegisterCommand(eventName, command);
        }

        public void UnregisterCommand(string eventName)
        {
            ControllerManager.GetInstance().UnregisterCommand(eventName);
        }

        public IMediator GetMediator(string mediatorName)
        {
            return ViewManager.GetInstance().GetMediator(mediatorName);
        }

        public void RegisterMediator(IMediator mediator)
        {
            ViewManager.GetInstance().RegisterMediator(mediator);
        }

		public void UnregisterMediator(string mediatorName)
		{
            ViewManager.GetInstance().UnregisterMediator(mediatorName);
		}

        public IProxy GetProxy(string proxyName)
        {
            return ModelManager.GetInstance().GetProxy(proxyName);
        }
        
        public void RegisterProxy(IProxy proxy)
        {
            ModelManager.GetInstance().RegisterProxy(proxy);
        }
		
        public void UnregisterProxy(IProxy proxy)
		{
            ModelManager.GetInstance().UnregisterProxy(proxy);
		}

        /// <summary>
        /// Triggers the event. Called by outside classes
        /// </summary>
        /// <param name="eventNode">Event node.</param>
        public void TriggerEvent(IEventMessage eventNode)
        {
            if (m_eventObserverList.ContainsKey(eventNode.Name))
            {
                IList<IEventObserver> handlers = m_eventObserverList[eventNode.Name];

                foreach(IEventObserver eventHandler in handlers)
                {
                    Debug.Log("Event: " + eventNode.Name + " is handled by : " + eventHandler.Name);
                    eventHandler.HandleEvent(eventNode);
                }
            }
        }

        /// <summary>
        /// Adds the event handler. Called by ControllerManager and ViewManager
        /// When RegisterCommand and RegisterMediator
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="eventHandler">Event handler.</param>
        public void AddEventHandler(string eventName, IEventObserver eventHandler)
        {
            if(m_eventObserverList.ContainsKey(eventName))
            {
                IList<IEventObserver> observers = m_eventObserverList[eventName];
                observers.Add(eventHandler);
            }
            else
            {
                IList<IEventObserver> observers = new List<IEventObserver>();
                observers.Add(eventHandler);
                m_eventObserverList.Add(eventName, observers);
            }
        }

        /// <summary>
        /// Removes the event handler.Called by ControllerManager and ViewManager
        /// when RemoveCommand and RemoveMediator
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="methodContext">Method context.</param>
        public void RemoveEventHandler(string eventName, object methodContext)
        {
            if(m_eventObserverList.ContainsKey(eventName))
            {
                IList<IEventObserver> handlers = m_eventObserverList[eventName];

                for (int i = 0; i < handlers.Count; i++)
                {
                    if(handlers[i].CompareMethodContext(methodContext))
                    {
                        handlers.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
