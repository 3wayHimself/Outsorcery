﻿/*
    License: http://www.apache.org/licenses/LICENSE-2.0
 */
namespace Outsorcery.ExampleWorkItems
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// An example work item
    /// </summary>
    [Serializable]
    public class ExampleWorkItem : ISerializableWorkItem<ExampleWorkResult>
    {
        /// <summary>
        /// Gets or sets the example list.
        /// </summary>
        /// <value>
        /// The example list.
        /// </value>
        public List<string> ExampleList { get; set; }

        /// <summary>
        /// Does the work asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An awaitable task, the result is the result of the work performed.</returns>
        public async Task<ExampleWorkResult> DoWorkAsync(System.Threading.CancellationToken cancellationToken)
        {
            Console.WriteLine("Work started on this system");

            var result = new ExampleWorkResult
                        {
                            IntegerValue = new Random().Next(1000)
                        };

            await Task.Delay(100, cancellationToken).ConfigureAwait(false);

            result.StringValue = string.Join(", ", ExampleList);

            Console.WriteLine(
                        "Work complete on this system, result - int: {0}. string: {1}.", 
                        result.IntegerValue, 
                        result.StringValue);

            return result;
        }
    }
}