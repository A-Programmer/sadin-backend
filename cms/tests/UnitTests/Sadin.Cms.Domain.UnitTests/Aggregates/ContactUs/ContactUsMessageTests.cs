namespace Sadin.Cms.Domain.UnitTests.Aggregates.ContactUs;

public class ContactUsMessageTests
{
    [Fact]
    public void Create_InputIsValid_ShouldCreateValidMessage()
    {
        string title = "Title";
        string content = "Content";
        string fullName = "Kamran Sadin";
        string email = "MrSadin@Gmail.Com";
        string phoneNumber = "+989308638095";
        
        ContactUsMessage contactMessage = ContactUsMessage.Create(title, content, fullName, email, phoneNumber);
        
        contactMessage.Title.Should().Be(title);
        contactMessage.Content.Should().Be(content);
        contactMessage.FullName.Should().Be(fullName);
        contactMessage.Email.Should().Be(email);
        contactMessage.PhoneNumber.Should().Be(phoneNumber);
    }
    
    [Fact]
    public void Create_TitleIsNull_ShouldThrowException()
    {
        Action action = () => { ContactUsMessage.Create(null, "Message content", "Kamran Sadin"); };

        action.Should().Throw<KSArgumentNullException>();
    }

    [Fact]
    public void MarkAsChecked_MessageNotCheckedBefore_StatusShouldReturnTrue()
    {
        ContactUsMessage message = ContactUsMessage.Create("Test title", "Message content", "Kamran Sadin");
        message.MarkAsChecked();

        message.IsChecked.Should().Be(true);
    }
    
    [Fact]
    public void MarkAsUnChecked_MessageIsCheckedBefore_StatusShouldReturnFals()
    {
        ContactUsMessage message = ContactUsMessage.Create("Test title", "Message content", "Kamran Sadin");
        message.MarkAsChecked();
        
        message.MarkAsUnChecked();

        message.IsChecked.Should().Be(false);
    }
}