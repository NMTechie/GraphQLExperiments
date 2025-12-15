using HotChocolate.Execution.Configuration;

namespace GraQL.Troubleshoot.Helper
{
    public static class DIRegistration
    {
        public static IRequestExecutorBuilder RegisterGraphQLTypes(this IRequestExecutorBuilder value)
        {
            IRequestExecutorBuilder var = value;
            var.AddType<Query>();
            return value;
        }
    }
}
