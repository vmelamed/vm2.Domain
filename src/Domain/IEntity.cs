// SPDX-License-Identifier: MIT
// Copyright (c) 2025-2026 Val Melamed

namespace vm2.Domain;

/// <summary>
/// Represents a DDD entity with a unique identifier.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// The unique identifier for the entity.
    /// </summary>
    [NotNull]
    object Id { get; }
}

/// <summary>
/// Represents a DDD entity with a unique identifier of type <typeparamref name="TEntityId"/>.
/// </summary>
/// <typeparam name="TEntityId">The type of the unique identifier for the entity.</typeparam>
public interface IEntity<TEntityId> : IEntity where TEntityId : notnull, IEquatable<TEntityId>
{
    /// <summary>
    /// The unique identifier for the entity.
    /// </summary>
    new TEntityId Id { get; }

    /// <summary>
    /// Default implementation of the <see cref="IEntity.Id"/> of the non-generic IEntity interface, returns the unique
    /// identifier <see cref="IEntity{TEntityId}.Id"/> as an object.
    /// </summary>
    /// <remarks>
    /// Caution: if <typeparamref name="TEntityId"/> is a value type, boxing will occur when accessing the Id through the
    /// non-generic IEntity interface, which may have performance implications.
    /// </remarks>
    object IEntity.Id => Id;
}
