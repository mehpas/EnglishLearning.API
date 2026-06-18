using EnglishLearning.Application.Common.Models;
using EnglishLearning.Application.Features.Kullanicilar.Commands.CreateKullanici;
using EnglishLearning.Application.Features.Kullanicilar.Commands.DeleteKullanici;
using EnglishLearning.Application.Features.Kullanicilar.Commands.UpdateKullanici;
using EnglishLearning.Application.Features.Kullanicilar.Dtos;
using EnglishLearning.Application.Features.Kullanicilar.Messages;
using EnglishLearning.Application.Features.Kullanicilar.Queries.GetKullaniciById;
using EnglishLearning.Application.Features.Kullanicilar.Queries.GetKullanicilar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KullanicilarController : ControllerBase
{
    private readonly IMediator _mediator;

    public KullanicilarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IReadOnlyList<KullaniciDto>>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetKullanicilarQuery(), cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<KullaniciDto>>.Ok(result, KullaniciMessages.Listed));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<KullaniciDto>>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetKullaniciByIdQuery(id), cancellationToken);
        return Ok(ApiResponse<KullaniciDto>.Ok(result, KullaniciMessages.Retrieved));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<int>>> Create([FromBody] CreateKullaniciDto dto, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new CreateKullaniciCommand(dto), cancellationToken);
        var response = ApiResponse<int>.Ok(id, KullaniciMessages.Created);
        return CreatedAtAction(nameof(GetById), new { id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(int id, [FromBody] UpdateKullaniciDto dto, CancellationToken cancellationToken)
    {
        await _mediator.Send(new UpdateKullaniciCommand(id, dto), cancellationToken);
        return Ok(ApiResponse<bool>.Ok(true, KullaniciMessages.Updated));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteKullaniciCommand(id), cancellationToken);
        return Ok(ApiResponse<bool>.Ok(true, KullaniciMessages.Deleted));
    }
}
