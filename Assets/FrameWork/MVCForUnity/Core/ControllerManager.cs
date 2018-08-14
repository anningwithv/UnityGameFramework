using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.MVCForUnity
{
    public class ControllerManager : IControllerManager
    {
        protected readonly Dictionary<string, Func<ICommand>> m_commandMaps = new Dictionary<string, Func<ICommand>>();

        protected static IControllerManager Instance = null;

        public static IControllerManager GetInstance()
        {
            if(Instance == null)
            {
                Instance = new ControllerManager();
            }

            return Instance;
        }

        public ControllerManager()
        {
            InitializeController();
        }

        protected virtual void InitializeController()
        {
            
        }

        public virtual bool HasCommand(string eventName)
        {
            bool hasCommand = m_commandMaps.ContainsKey(eventName);
            return hasCommand;
        }

        public virtual void RegisterCommand(string eventName, Func<ICommand> command)
        {
            if(!m_commandMaps.ContainsKey(eventName))
            {
                m_commandMaps.Add(eventName, command);

                Facade.GetInstance().AddEventHandler(eventName, new EventObserver(ExecuteCommand, this, this.GetType().ToString()));
            }
        }

        public virtual void UnregisterCommand(string eventName)
		{
            if(m_commandMaps.ContainsKey(eventName))
            {
                m_commandMaps.Remove(eventName);

                Facade.GetInstance().RemoveEventHandler(eventName, this);
            }
		}

        public virtual void ExecuteCommand(IEventMessage eventNode)
        {
            if (m_commandMaps.ContainsKey(eventNode.Name))
            {
                Func<ICommand> commandFunc = m_commandMaps[eventNode.Name];
                ICommand command = commandFunc();
                command.Execute(eventNode);
            }
        }
    }
}
