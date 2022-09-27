
namespace Kaihatsu.CardManager.Core;

public abstract class BaseEntity : IEquatable<BaseEntity>
{
    public Guid Id { get; set; }

    public bool Equals(BaseEntity? other)
    {
        if (other is null)
            return false;
        if (ReferenceEquals(this, other))
            return true;

        return Id == other.Id;
    }

    public bool Equals(object? other)
    {
        if (other is null)
            return false;
        if (ReferenceEquals(this, other))
            return true;
        if (other.GetType() != typeof(BaseEntity))
            return false;

        return Equals((BaseEntity)other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
