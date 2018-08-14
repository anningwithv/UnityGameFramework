using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.MVCForUnity
{
    public class ViewManager : IViewManager
    {
        protected readonly Dictionary<string, IMediator> m_mediatorMap = new Dictionary<string, IMediator>();

        protected static IViewManager Instance = null;

        public static IViewManager GetInstance()
        {
            if (Instance == null)
                Instance = new ViewManager();

            return Instance;
        }

        public virtual IMediator GetMediator(string mediatorName)
        {
            if (m_mediatorMap.ContainsKey(mediatorName))
            {
                return m_mediatorMap[mediatorName];
            }

            return null;
        }

        public virtual void  RegisterMediator(IMediator mediator)
        {
            if (!m_mediatorMap.ContainsKey(mediator.Name))
            {
                m_mediatorMap.Add(mediator.Name, mediator);

                string[] interests = mediator.ListInterestEvent();

                if(interests != null && interests.Length > 0)
                {
                    IEventObserver eventHandler = new EventObserver(mediator.HandleEvent, mediator, mediator.GetType().ToString());

                    for (int i = 0; i < interests.Length; i++)
                    {
                        Facade.GetInstance().AddEventHandler(interests[i], eventHandler);
                    }
                }

                mediator.OnRegister();
            }
        }
		
        public virtual void UnregisterMediator(string mediatorName)
		{
            if (m_mediatorMap.ContainsKey(mediatorName))
            {
                IMediator mediator = m_mediatorMap[mediatorName];
                string[] interesets = mediator.ListInterestEvent();
                for (int i = 0; i < interesets.Length; i++)
                {
                    Facade.GetInstance().RemoveEventHandler(interesets[i], mediator);
                }

                mediator.OnRemove();

                m_mediatorMap.Remove(mediatorName);
            }
		}

        public virtual void TriggerEvent(string eventName)
        {

        }

    }
}
