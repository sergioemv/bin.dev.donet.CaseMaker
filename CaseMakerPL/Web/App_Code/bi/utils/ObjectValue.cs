using System;
using ISNet.WebUI.WebGrid;

namespace bi.utils
{
    /// <summary>
    /// Autor: portiz
    /// This class helps to manage a object-key-value reference
    /// </summary>
    public class ObjectValue
    {
        private readonly String key;
        private readonly String value;
        private Object myObject;

        [PrimaryKey()]
        public string Key
        {
            get { return key; }
        }

        public string Value
        {
            get { return value; }
        }

        public object MyObject
        {
            get { return myObject; }
            set { myObject = value; }
        }

        public ObjectValue(string key, string value, object myObject)
        {
            this.key = key;
            this.value = value;
            this.myObject = myObject;
        }
    }
}