// SPDX-License-Identifier: MIT
// Copyright (c) 2025-2026 Val Melamed

namespace vm2.Domain;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents an object that can be validated. Implementing this interface indicates that the object has validation logic that
/// can be executed to ensure its state is consistent and meets defined rules.
/// </summary>
public interface IValidatable
{
    /// <summary>
    /// Validates the current object in the specified context and returns a boolean indicating whether the object is in a valid
    /// state.
    /// </summary>
    /// <param name="validationMessages">
    /// A collection that will be populated with validation messages if the object is not in a valid state.
    /// </param>
    /// <param name="ct">A cancellation token that can be used to cancel the validation operation.</param>
    /// <returns>
    /// A task that represents the asynchronous validation operation. The task result is true if the object is valid; otherwise,
    /// false.
    /// </returns>
    /// <remarks>
    /// Implementers should ensure that the validation logic is efficient and does not perform long-running operations on the
    /// calling thread.
    /// The context parameter allows for flexible validation scenarios where additional information or constraints may be
    /// required.
    /// Note that the return value is a <see cref="ValueTask{Boolean}"/> which has specific usage patterns and implications:
    /// <see href="https://learn.microsoft.com/en-us/dotNet/api/system.threading.tasks.valuetask?view=net-10.0#remarks"/>.
    /// </remarks>
    ValueTask<bool> TryValidateAsync(out IEnumerable<string>? validationMessages, CancellationToken ct = default);

    /// <summary>
    /// Validates the current object in the specified context and returns a boolean indicating whether the object is in a valid
    /// state.
    /// </summary>
    /// <param name="context">
    /// The context in which to validate the object. This can be used to provide additional information or context-specific
    /// constraints for the validation process.
    /// </param>
    /// <param name="validationMessages">
    /// A collection that will be populated with validation messages if the object is not in a valid state.
    /// </param>
    /// <param name="ct">A cancellation token that can be used to cancel the validation operation.</param>
    /// <returns>
    /// A task that represents the asynchronous validation operation. The task result is true if the object is valid; otherwise,
    /// false.
    /// </returns>
    /// <remarks>
    /// Implementers should ensure that the validation logic is efficient and does not perform long-running operations on the
    /// calling thread.
    /// The context parameter allows for flexible validation scenarios where additional information or constraints may be
    /// required.
    /// Note that the return value is a <see cref="ValueTask{Boolean}"/> which has specific usage patterns and implications:
    /// <see href="https://learn.microsoft.com/en-us/dotNet/api/system.threading.tasks.valuetask?view=net-10.0#remarks"/>.
    /// </remarks>
    ValueTask<bool> TryValidateAsync<TContext>(TContext context, out IEnumerable<string>? validationMessages, CancellationToken ct = default);

    /// <summary>
    /// Validates the current object in the specified context and throws an InvalidOperationException if the object is not in a valid
    /// state. This method provides a way to enforce validation and handle validation failures through exceptions rather than boolean
    /// return values.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <param name="context"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    async ValueTask ValidateAsync<TContext>(TContext context, CancellationToken ct = default)
    {
        if (!await TryValidateAsync(context, ct).ConfigureAwait(false))
            throw new FluentValidation.ValidationException("Validation failed.");
    }
}
