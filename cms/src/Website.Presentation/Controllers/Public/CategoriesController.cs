using KSFramework;
using KSFramework.Exceptions;
using KSFramework.Responses.SuccessResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Categories.Queries.GetCategories;
using Website.Application.Categories.Queries.GetCategoryBySlug;
using Website.Common.WebFrameworks.Routing;
using Website.Presentation.ViewModels.BlogViewModels.PostCategories.GetAllPostCategories;
using Website.Presentation.ViewModels.BlogViewModels.PostCategories.GetPostCategoryBySlug;

namespace Website.Presentation.Controllers;

public class CategoriesController : PublicBaseController
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator) => _mediator = mediator ?? throw new KSArgumentNullException(nameof(mediator));
    
    [HttpGet(Routes.Categories.Get.GetAll)]
    [ProducesResponseType(typeof(ResultMessage<List<GetAllCategoryItemViewModel>>), 200)]
    public async Task<IActionResult> GetAll()
    {
        GetCategoriesQuery getCategoriesQuery = new();
        var result = await _mediator.Send(getCategoriesQuery);
        return CustomOk<List<GetAllCategoryItemViewModel>>(
            result.Select((x => new GetAllCategoryItemViewModel(x))).ToList());
    }
    
    [HttpGet(Routes.Categories.Get.GetBySlug)]
    [ProducesResponseType(typeof(OkResponse<GetCategoryBySlugItemViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(string slug)
    {
        GetCategoryBySlugQuery getCategoryBySlugQuery = new(slug);
        var resultDto = await _mediator.Send(getCategoryBySlugQuery);
        var resultViewModel = new GetCategoryBySlugItemViewModel(resultDto);
        
        return CustomOk<GetCategoryBySlugItemViewModel>(resultViewModel);
    }
}