using System;
using System.Collections.Generic;

namespace BoilerplateRomi.Models
{
    public class Observable<T>
    {
        public Observable() { }

        public Observable(T value)
        {
            _model = value;
        }
        
        private T _model;
        public event Action<T> OnModelUpdate;

        public void SetModel(T model)
        {
            _model = model;
            OnModelUpdate?.Invoke(_model);
        }

        public T GetModel()
        {
            return _model;
        }
    }
    public class ObservableList<T>
    {
        private List<T> _model = new List<T>();
        public event Action<List<T>> OnModelUpdate;
        public event Action<T> OnModelAdd;
        public event Action<T> OnModelRemoved;

        public void AddMember(T member)
        {
            if (_model.Contains(member))
            {
                var index = _model.FindIndex(x => x.Equals(member));
                _model[index] = member;
            }
            else
            {
                _model.Add(member);
            }
            
            OnModelAdd?.Invoke(member);
            OnModelUpdate?.Invoke(_model);
        }

        public void RemoveMember(T member)
        {
            if (!_model.Contains(member))
            {
                Extensions.LogWarning($"Observable List: {_model} does not contains {member}, skipping removal");
                return;
            }

            _model.Remove(member);
            OnModelRemoved?.Invoke(member);
            OnModelUpdate?.Invoke(_model);
        }

        public List<T> GetModel()
        {
            return _model;
        }

        public void SetModel(List<T> model)
        {
            _model = model;
            OnModelUpdate?.Invoke(_model);
        }
    }

    public class ObservableDict<T, U>
    {
        private readonly Dictionary<T, U> _model = new Dictionary<T, U>();
        public event Action<Dictionary<T, U>> OnModelUpdate;
        public event Action<T, U> OnModelAdd;
        public event Action<T, U> OnModelRemoved;

        public void AddMember(T key, U value)
        {
            _model[key] = value;
            OnModelAdd?.Invoke(key, value);
            OnModelUpdate?.Invoke(_model);
        }

        public void RemoveMember(T key)
        {
            if (!_model.ContainsKey(key))
            {
                Extensions.LogWarning($"Observable Dict: {_model} does not contains key:{key}, skipping removal");
                return;
            }

            var value = _model[key];
            _model.Remove(key);
            OnModelRemoved?.Invoke(key, value);
            OnModelUpdate?.Invoke(_model);
        }

        public bool TryGetValue(T key, out U value)
        {
            var result = _model.TryGetValue(key, out value);
            return result;
        }

        public Dictionary<T, U> GetModel()
        {
            return _model;
        }
    }
}