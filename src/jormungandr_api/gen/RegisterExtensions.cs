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
    /// Extension methods for Register.
    /// </summary>
    public static partial class RegisterExtensions
    {
            /// <summary>
            /// Registers new leader
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// Leader secret
            /// </param>
            public static int? Leader(this IRegister operations, Body body)
            {
                return operations.LeaderAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Registers new leader
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// Leader secret
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<int?> LeaderAsync(this IRegister operations, Body body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.LeaderWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}