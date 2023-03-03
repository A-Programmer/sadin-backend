using System.Runtime.Serialization;
using KSFramework.Primitives;

namespace Website.Domain.Aggregates.ContactUsMessages;

[Serializable]
public sealed class ContactUsMessage : AggregateRootWithSoftDelete, ISerializable
{
    public string? FullName { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; }
    public DateTimeOffset? CheckedDate { get; private set; }
    public bool IsChecked { get; private set; }
    
    
    private ContactUsMessage(Guid id, string title, string content, DateTimeOffset createdAt,
        bool isChecked, DateTimeOffset? checkedDate = null, string? fullName = null,
        string? email = null, string? phoneNumber = null)
            : base(id)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        Title = title ?? throw new KSArgumentNullException(nameof(title));
        Content = content ?? throw new KSArgumentNullException(nameof(content));
        CreatedDate = createdAt;
        CheckedDate = checkedDate;
        IsChecked = isChecked;
    }

    public static ContactUsMessage Create(string title, string content, string? fullName = null, string? email = null,
        string? phoneNumber = null)
    {
        ContactUsMessage message = new(Guid.NewGuid(), title, content, DateTimeOffset.UtcNow, false, null, fullName,
            email, phoneNumber);
        // AddDomainEvent(new );
        return message;
    }

    public void MarkAsChecked()
    {
        IsChecked = true;
        CheckedDate = DateTimeOffset.UtcNow;
        
        // TODO : Adding Domain Event
    }
    public void MarkAsUnChecked() => IsChecked = false;

    protected ContactUsMessage(Guid id) : base(id) { }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Id), Id);
        info.AddValue(nameof(FullName), FullName);
        info.AddValue(nameof(Email), Email);
        info.AddValue(nameof(PhoneNumber), PhoneNumber);
        info.AddValue(nameof(Title), Title);
        info.AddValue(nameof(Content), Content);
        info.AddValue(nameof(CreatedDate), CreatedDate);
        info.AddValue(nameof(CheckedDate), CheckedDate);
        info.AddValue(nameof(IsChecked), IsChecked);
    }
}