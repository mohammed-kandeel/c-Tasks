namespace C48_G02_ADV01
{
    public class Cache<TKey, TValue> where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _dictionary;

        public Cache()
        {
            _dictionary = new Dictionary<TKey, TValue>();
        }

        //Add, Get, Remove, Contains

        public void Add(TKey key, TValue value)
        {
            _dictionary[key] = value;
        }

        public TValue? Get(TKey key)
        {

            if (_dictionary.ContainsKey(key))
                return _dictionary[key];

            return default(TValue);
        }

        public bool Contains(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        public void Remove(TKey key)
        {
            _dictionary.Remove(key);
        }

    }
}
