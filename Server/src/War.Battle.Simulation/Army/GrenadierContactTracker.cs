using System.Numerics;

namespace War.BattleServer;

/// <summary>Retains independently supported contacts so revisiting a live floor/wall pair is not a new entry.</summary>
internal sealed class GrenadierContactTracker
{
    private const float DistanceTolerance = 0.001f;
    private readonly Dictionary<ContactIdentity, Vector3> _contacts = [];

    internal int Count => _contacts.Count;

    internal bool Enter(ShotCollision contact, Vector3 normal)
    {
        ContactIdentity identity = Identity(contact);
        bool isNewContact = !_contacts.ContainsKey(identity);
        _contacts[identity] = normal;
        return isNewContact;
    }

    internal void ReleaseSeparated(ShotCollision? currentContact, Vector3 position, float range,
        Func<Vector3, Vector3, float, ShotCollision?> trace)
    {
        ContactIdentity? current = currentContact == null ? null : Identity(currentContact);
        foreach (var contact in _contacts.ToArray())
        {
            if (contact.Key == current)
            {
                continue;
            }

            ShotCollision? support = trace(position, -contact.Value, range);
            if (support != null && (!float.IsFinite(support.Distance) || support.Distance < 0f ||
                support.Distance > range + DistanceTolerance || string.IsNullOrEmpty(support.SourcePath)))
            {
                throw new InvalidDataException("Grenadier support lost its source collision authority.");
            }

            if (support == null || (!support.Static && !support.SourceDestroyable) || Identity(support) != contact.Key)
            {
                _contacts.Remove(contact.Key);
            }
        }
    }

    private static ContactIdentity Identity(ShotCollision contact)
    {
        if (string.IsNullOrEmpty(contact.SourcePath))
        {
            throw new InvalidDataException("Grenadier contact lacks a source collider identity.");
        }

        // Source paths repeat across instantiated soldiers and passengers. Retain their host-owned identities too.
        return new ContactIdentity
        {
            SourcePath = contact.SourcePath,
            ColliderIndex = contact.ColliderIndex,
            PlayerId = contact.PlayerId,
            EntityId = contact.DynamicEntityId,
            PartId = contact.DynamicPartId,
            PassengerRole = contact.DynamicPassengerRole,
            RepairDronePathIndex = contact.DynamicRepairDronePathIndex,
            BonusBoxId = contact.BonusBoxId
        };
    }

    private sealed record ContactIdentity
    {
        public required string SourcePath { get; init; }

        public int? ColliderIndex { get; init; }

        public string? PlayerId { get; init; }

        public ulong? EntityId { get; init; }

        public int? PartId { get; init; }

        public string? PassengerRole { get; init; }

        public int? RepairDronePathIndex { get; init; }

        public string? BonusBoxId { get; init; }
    }
}
