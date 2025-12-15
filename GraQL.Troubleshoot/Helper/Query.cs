namespace GraQL.Troubleshoot.Helper
{
    public class Query
    {
        public string SayHello(string greetings = "Nilesh") => $"Hello, {greetings}!";

        public string SayHello2(int greetings = 5) => $"Hello, {greetings}!";
    }
}
