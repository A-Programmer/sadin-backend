using KSFramework;
using KSFramework.Exceptions;
using KSFramework.Responses.SuccessResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Application.PostCategories.Queries.GetPostCategories;
using Website.Application.PostCategories.Queries.GetPostCategoryBySlug;
using Website.Common.WebFrameworks.Routing;
using Website.Presentation.ViewModels.BlogViewModels.PostCategories.GetAllPostCategories;
using Website.Presentation.ViewModels.BlogViewModels.PostCategories.GetPostCategoryBySlug;

namespace Website.Presentation.Controllers;

public class PostCategoriesController : PublicBaseController
{
    private readonly IMediator _mediator;

    public PostCategoriesController(IMediator mediator) => _mediator = mediator ?? throw new KSArgumentNullException(nameof(mediator));
    
    [HttpGet(Routes.Posts.Categories.Get.GetAll)]
    [ProducesResponseType(typeof(ResultMessage<List<GetAllPostCategoryItemViewModel>>), 200)]
    public async Task<IActionResult> GetAll()
    {
        GetPostCategoriesQuery getPostCategoriesQuery = new();
        var result = await _mediator.Send(getPostCategoriesQuery);
        return CustomOk<List<GetAllPostCategoryItemViewModel>>(
            result.Select((x => new GetAllPostCategoryItemViewModel(x))).ToList());
    }
    
    [Authorize]
    [HttpGet(Routes.Posts.Categories.Get.GetBySlug)]
    [ProducesResponseType(typeof(OkResponse<GetPostCategoryBySlugItemViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(string slug)
    {
        GetPostCategoryBySlugQuery getPostCategoryBySlugQuery = new(slug);
        var resultDto = await _mediator.Send(getPostCategoryBySlugQuery);
        var resultViewModel = new GetPostCategoryBySlugItemViewModel(resultDto);
        
        return CustomOk<GetPostCategoryBySlugItemViewModel>(resultViewModel);
    }
}