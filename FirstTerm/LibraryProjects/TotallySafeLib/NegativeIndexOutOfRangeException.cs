namespace CustomExceptionHandling
{
    public class NegativeIndexOutOfRangeException : Exception
    {
        public NegativeIndexOutOfRangeException () : base () { }

        public NegativeIndexOutOfRangeException (string message) : base (message) { }
        
        public NegativeIndexOutOfRangeException (string message, Exception inner) : base (message, inner) { }
    }
}
