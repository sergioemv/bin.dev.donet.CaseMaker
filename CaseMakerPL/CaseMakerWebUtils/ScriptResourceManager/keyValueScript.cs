namespace CaseMakerWebUtils.ScriptResourceManager
{
    internal class keyValueScript
    {
        private string _key;
        private string _value;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public keyValueScript(string _key, string _value)
        {
            this._key = _key;
            this._value = _value;
        }
    }
}