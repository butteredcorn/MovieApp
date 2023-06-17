namespace MovieApp.Exceptions
{
    [Serializable]
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException()
            : base(CreateDefaultMessage(typeof(T).Name)) { }

        public EntityNotFoundException(string message)
            : base(message) { }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

        private static string CreateDefaultMessage(string typeName)
        {
            return $"The matching entity \"{typeName}\" could not be found.";
        }
    }
}
