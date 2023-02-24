using KSFramework.Responses.SuccessResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Website.Application.ContactUsMessages.Commands.CreateMessage;
using Website.Common.WebFrameworks.Routing;
using Website.Presentation.ViewModels.ContactUs;

namespace Website.Presentation.Controllers;

public class ContactUsController : PublicBaseController
{
    private readonly IMediator _mediator;
    public ContactUsController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    
    [HttpPost(Routes.ContactUs.Post.Add)]
    [ProducesResponseType(typeof(OkResponse<Guid>), 200)]
    public async Task<IActionResult> Post(CreateContactUsMessageViewModel model)
    {
        CreateContactUsMessageCommand createCommand = new(model.Title, model.Content, model.FullName, model.Email, model.PhoneNumber);
        var result = await _mediator.Send(createCommand);
        
        return Ok(result);
    }
}