using System;
using System.Collections.Generic;

namespace BoilerplateRomi
{
    public enum EventId
    {
        EventTest,
        OnBackPressedAndroid
    }
    
    public class EventController
    {
        private static readonly Dictionary<EventId, List<Action>> _actions = new Dictionary<EventId, List<Action>>();
        private static readonly Dictionary<EventId, Dictionary<Type, List<object>>> _actionsT = new Dictionary<EventId, Dictionary<Type, List<object>>>();
        private static readonly Dictionary<EventId, Dictionary<(Type, Type), List<object>>> _actionsT2 = new Dictionary<EventId, Dictionary<(Type, Type), List<object>>>();
        private static readonly Dictionary<EventId, Dictionary<(Type, Type, Type), List<object>>> _actionsT3 = new Dictionary<EventId, Dictionary<(Type, Type, Type), List<object>>>();

        public static void AddListener(EventId eventName, Action action)
        {
            if (_actions.ContainsKey(eventName))
            {
                if (_actions[eventName].Contains(action))
                {
                    Extensions.LogWarning($"collection already contains {action.Method.Name}, skipping");
                }
                else
                {
                    _actions[eventName].Add(action);
                }
            }
            else
            {
                var newList = new List<Action>();
                newList.Add(action);
                _actions.Add(eventName, newList);
            }
        }

        public static void AddListener<T>(EventId eventName, Action<T> action)
        {
            var type = typeof(T);
            var list = new List<object>();

            if (_actionsT.ContainsKey(eventName))
            {
                if (_actionsT[eventName].TryGetValue(type, out var collection))
                {
                    if (collection.Contains(action))
                    {
                        Extensions.LogWarning($"collection already contains {action.Method.Name}, skipping");
                        return;
                    }

                    collection.Add(action);
                }
                else
                {
                    _actionsT[eventName].Add(type, list);
                    _actionsT[eventName][type].Add(action);
                }    
            }
            else
            {
                var newDict = new Dictionary<Type, List<object>>();
                newDict.Add(type, list);
                newDict[type].Add(action);
                _actionsT.Add(eventName, newDict);
            }
        }

        public static void AddListener<T1, T2>(EventId eventName, Action<T1, T2> action)
        {
            var type = (typeof(T1), typeof(T2));
            var list = new List<object>();

            if (_actionsT2.ContainsKey(eventName))
            {
                if (_actionsT2[eventName].TryGetValue(type, out var collection))
                {
                    if (collection.Contains(action))
                    {
                        Extensions.LogWarning($"collection already contains {action.Method.Name}, skipping");
                        return;
                    }

                    collection.Add(action);
                }
                else
                {
                    _actionsT2[eventName].Add(type, list);
                    _actionsT2[eventName][type].Add(action);
                }
            }
            else
            {
                var newDict = new Dictionary<(Type, Type), List<object>>();
                newDict.Add(type, list);
                newDict[type].Add(action);
                _actionsT2.Add(eventName, newDict);
            }
        }

        public static void AddListener<T1, T2, T3>(EventId eventName, Action<T1, T2, T3> action)
        {
            var type = (typeof(T1), typeof(T2), typeof(T3));
            var list = new List<object>();

            if (_actionsT3.ContainsKey(eventName))
            {
                if (_actionsT3[eventName].TryGetValue(type, out var collection))
                {
                    if (collection.Contains(action))
                    {
                        Extensions.LogWarning($"collection already contains {action.Method.Name}, skipping");
                        return;
                    }

                    collection.Add(action);
                }
                else
                {
                    _actionsT3[eventName].Add(type, list);
                    _actionsT3[eventName][type].Add(action);
                }
            }
            else
            {
                var newDict = new Dictionary<(Type, Type, Type), List<object>>();
                newDict.Add(type, list);
                newDict[type].Add(action);
                _actionsT3.Add(eventName, newDict);
            }
        }

        public static void RemoveListener(EventId eventName, Action action)
        {
            if (!_actions.ContainsKey(eventName))
            {
                Extensions.LogWarning($"Collection does not contains {eventName} Key");
                return;
            }

            try
            {
                _actions[eventName].Remove(action);
            }
            catch (NullReferenceException e)
            {
                Extensions.LogError($"Error removing {action.Method.Name} from collection, it may have been already removed: {e.Message}");
            }
        }

        public static void RemoveListener<T>(EventId eventName, Action<T> action)
        {
            if (!_actionsT.ContainsKey(eventName))
            {
                Extensions.LogWarning($"Collection does not contains {eventName} Key");
                return;
            }

            if (!_actionsT[eventName].TryGetValue(typeof(T), out var collection)) return;
            try
            {
                collection.Remove(action);
            }
            catch (NullReferenceException e)
            {
                Extensions.LogError($"Error removing {action.Method.Name} from collection, it may have been already removed: {e.Message}");
            }
        }

        public static void RemoveListener<T1, T2>(EventId eventName, Action<T1, T2> action)
        {
            var type = (typeof(T1), typeof(T2));

            if (!_actionsT2.ContainsKey(eventName))
            {
                Extensions.LogWarning($"Collection does not contains {eventName} Key");
                return;
            }

            if (!_actionsT2[eventName].TryGetValue(type, out var collection)) return;
            try
            {
                collection.Remove(action);
            }
            catch (NullReferenceException e)
            {
                Extensions.LogError($"Error removing {action.Method.Name} from collection, it may have been already removed: {e.Message}");
            }
        }

        public static void RemoveListener<T1, T2, T3>(EventId eventName, Action<T1, T2, T3> action)
        {
            var type = (typeof(T1), typeof(T2), typeof(T3));

            if (!_actionsT3.ContainsKey(eventName))
            {
                Extensions.LogWarning($"Collection does not contains {eventName} Key");
                return;
            }

            if (!_actionsT3[eventName].TryGetValue(type, out var collection)) return;
            try
            {
                collection.Remove(action);
            }
            catch (NullReferenceException e)
            {
                Extensions.LogError($"Error removing {action.Method.Name} from collection, it may have been already removed: {e.Message}");
            }
        }

        public static void TriggerActions(EventId eventId)
        {
            if (_actions.TryGetValue(eventId, out var actions))
            {
                foreach (var act in actions)
                {
                    act?.Invoke();
                }
            }
            else
            {
                Extensions.LogWarning($"Can't find action collection with event Id: {eventId}, nothing to invoke");
            }
        }

        public static void TriggerActions<T>(EventId eventId, T arg)
        {
            var type = typeof(T);
            
            if (!_actionsT.ContainsKey(eventId)) return;
            if (!_actionsT[eventId].ContainsKey(type)) return;
            
            foreach (var obj in _actionsT[eventId][type])
            {
                var act = obj as Action<T>;

                act?.Invoke(arg);
            }
        }

        public static void TriggerActions<T1, T2>(EventId eventId, T1 arg1, T2 arg2)
        {
            var type = (typeof(T1), typeof(T2));
            
            if (!_actionsT2.ContainsKey(eventId)) return;
            if (!_actionsT2[eventId].ContainsKey(type)) return;
            
            foreach (var obj in _actionsT2[eventId][type])
            {
                var act = obj as Action<T1, T2>;
                Extensions.LogWarning(act?.Method.Name);
                act?.Invoke(arg1, arg2);
            }
        }

        public static void TriggerActions<T1, T2, T3>(EventId eventId, T1 arg1, T2 arg2, T3 arg3)
        {
            var type = (typeof(T1), typeof(T2), typeof(T3));

            if (!_actionsT3.ContainsKey(eventId)) return;
            if (!_actionsT3[eventId].ContainsKey(type)) return;
            
            foreach (var obj in _actionsT3[eventId][type])
            {
                var act = obj as Action<T1, T2, T3>;

                act?.Invoke(arg1, arg2, arg3);
            }
        }

        public static void ClearActions()
        {
            _actions.Clear();
            _actionsT.Clear();
            _actionsT2.Clear();
            _actionsT3.Clear();
        }
    }
}