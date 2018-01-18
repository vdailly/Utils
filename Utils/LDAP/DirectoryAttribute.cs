using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;
using System.Threading;

namespace Utils.LDAP
{

    public delegate void DirectoryAttributeEventHandler(object sender, EventArgs e);

    public class DirectoryAttributeEventArgs : EventArgs
    {
        public DirectoryAttributeEventArgs() : base() { }
    }

    public class DirectoryAttribute
    {
        private object locker = new object();
        private int update = 0;

        private List<DirectoryAttributeModification> updates = new List<DirectoryAttributeModification>();
        private List<DirectoryAttributeModification> previous = new List<DirectoryAttributeModification>();
        private List<object> values = new List<object>();

        #region Events
        private event DirectoryAttributeEventHandler _OnBeforeAdd;
        private event DirectoryAttributeEventHandler _OnAdd;
        private event DirectoryAttributeEventHandler _OnBeforeRemove;
        private event DirectoryAttributeEventHandler _OnRemove;
        private event DirectoryAttributeEventHandler _OnBeforeClear;
        private event DirectoryAttributeEventHandler _OnClear;

        public event DirectoryAttributeEventHandler OnBeforeAdd
        {
            add { lock (locker) { _OnBeforeAdd += value; } }
            remove { lock (locker) { _OnBeforeAdd -= value; } }
        }

        public event DirectoryAttributeEventHandler OnAdd
        {
            add { lock (locker) { _OnAdd += value; } }
            remove { lock (locker) { _OnAdd -= value; } }
        }

        public event DirectoryAttributeEventHandler OnBeforeRemove
        {
            add { lock (locker) { _OnBeforeRemove += value; } }
            remove { lock (locker) { _OnBeforeRemove -= value; } }
        }

        public event DirectoryAttributeEventHandler OnRemove
        {
            add { lock (locker) { _OnRemove += value; } }
            remove { lock (locker) { _OnRemove -= value; } }
        }

        public event DirectoryAttributeEventHandler OnBeforeClear
        {
            add { lock (locker) { _OnBeforeClear += value; } }
            remove { lock (locker) { _OnBeforeClear -= value; } }
        }

        public event DirectoryAttributeEventHandler OnClear
        {
            add { lock (locker) { _OnClear += value; } }
            remove { lock (locker) { _OnClear -= value; } }
        }
        #endregion

        #region Properties
        public readonly string Name;
        public IEnumerable<object> Values {
            get {
                lock(locker)
                {
                    return new List<object>(values);
                }
            }
        }
        #endregion

        #region Ctor
        public DirectoryAttribute(string name) {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
        }
        #endregion


        /// <exception cref="ArgumentNullException" />
        public void Add(string value) { }
        public void Add(byte[] value) { }
        public void AddRange(string[] values) { }
        public void AddRange(byte[][] values) { }
        public void Remove(string value) { }
        public void Remove(byte[] value) { }
        public void RemoveRange(string[] values) { }
        public void RemoveRange(byte[][] values) { }
        public void Clear() { }

        private bool previouslyRemoved() { throw new NotImplementedException(); }
        private bool previouslyAdded() { throw new NotImplementedException(); }

        #region Event Handlers
        private void OnBeforeAddEventHandler(object sender, EventArgs e) { }
        private void OnAddEventHandler(object sender, EventArgs e) { }
        private void OnBeforeRemoveEventHandler(object sender, EventArgs e) { }
        private void OnRemoveEventHandler(object sender, EventArgs e) { }
        private void OnBeforeClearEventHandler(object sender, EventArgs e) { }
        private void OnClearEventHandler(object sender, EventArgs e) { }
        #endregion
 
    }
}
