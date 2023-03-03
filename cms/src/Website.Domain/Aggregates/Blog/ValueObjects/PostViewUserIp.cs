using System.Runtime.Serialization;
using KSFramework.Primitives;
using KSFramework.Utilities;

namespace Website.Domain.Aggregates.Blog.ValueObjects;

[Serializable]
public sealed class PostViewUserIp : ValueObject, ISerializable
{
    private const int MaxLength = 25;
    public string Value { get; private set; }

    private PostViewUserIp(string value)
    {
        Value = value;
    }

    public static PostViewUserIp Create(string userIpAddress)
    {
        if (!userIpAddress.HasValue()) throw new KSArgumentNullException($"{nameof(userIpAddress)}");
        if (userIpAddress.Length > MaxLength)
            throw new KSValidationException($"{userIpAddress} must be less than {MaxLength}");
        
        return new PostViewUserIp(userIpAddress);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    protected PostViewUserIp() { }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Value), Value);
    }
}