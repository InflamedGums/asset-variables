using System;
using System.Collections.Generic;
using UnityEngine;

namespace LovelyBytes.AssetVariables
{
    /// <summary>
    /// Base class for scriptable objects that wrap a given type.
    /// </summary>
    public abstract class Variable<TType> : ScriptableObject
    {
        /// <summary>
        /// Subscribe to this Event to get notified when the value of this object changes.
        /// Provides the old and new values as parameters.
        /// </summary>
        public event Action<TType, TType> OnValueChanged;

        private const int _maxRecursionDepth = 100;
        private readonly object _lockObject = new();
        
        private bool _isNotifyingListeners = false;
        private int _recursionDepth = 0;
        private readonly Queue<TType> _pendingSetOperations = new();

        public TType Value
        {
            get
            {
                lock (_lockObject)
                {
                    return _value;
                }
            }
            set
            {
                lock (_lockObject)
                {
                    if (_isNotifyingListeners)
                    {
                        if (_recursionDepth < _maxRecursionDepth)
                        {
                            ++_recursionDepth;
                            _pendingSetOperations.Enqueue(value);
                        }
                        else
                        {
                            Debug.LogError($"Encountered possible endless recursion while setting the Value for {name} to {value}, " +
                                           $"which can happen by repeatedly setting the Value from within an OnValueChanged callback.");
                        }
                    }
                    else
                    {
                        
                        try
                        {
                            OnBeforeSet(ref value);
                            
                            _isNotifyingListeners = true;
                            
                            TType oldValue = _value;
                            _value = value;
                            OnValueChanged?.Invoke(oldValue, _value);
                        }
                        catch (Exception)
                        {
                            _recursionDepth = 0;
                            _pendingSetOperations.Clear();
                            throw;
                        }
                        finally
                        {
                            _isNotifyingListeners = false;
                        }

                        if (_pendingSetOperations.Count < 1)
                        {
                            _recursionDepth = 0;
                            return;
                        }
                        
                        Value = _pendingSetOperations.Dequeue();
                    }
                }
            }
        }

        /// <summary>
        /// Override this function to apply additional checks and modifications on the value before setting it
        /// </summary>
        /// <param name="newValue">The value that is about to be set.</param>
        protected virtual void OnBeforeSet(ref TType newValue)
        {  } 

        public void SetWithoutNotify(TType newValue)
        {
            lock (_lockObject)
            {
                OnBeforeSet(ref newValue);
                _value = newValue;
            }
        }
        
        [SerializeField, GetSet(nameof(Value))]
        private TType _value;
    }
}
