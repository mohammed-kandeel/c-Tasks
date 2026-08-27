namespace C48_G02_ADV01
{
    internal class Conteiner<T>
    {
        private T? value;
        public T? GetValue() { return value; }

        public void Add(T? value)
        {
            this.value = value;
        }
    }
}
