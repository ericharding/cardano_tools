// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Jormungandr
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Shutdown.
    /// </summary>
    public static partial class ShutdownExtensions
    {
            /// <summary>
            /// Starts node shutdown procedure
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void Node(this IShutdown operations)
            {
                operations.NodeAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Starts node shutdown procedure
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task NodeAsync(this IShutdown operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.NodeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
