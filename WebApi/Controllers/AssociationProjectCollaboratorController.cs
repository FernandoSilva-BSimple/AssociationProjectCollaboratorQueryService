using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi;

[ApiController]
[Route("api/associationsPC")]
public class AssociationProjectCollaboratorController : ControllerBase
{
    private readonly AssociationProjectCollaboratorService _service;

    public AssociationProjectCollaboratorController(AssociationProjectCollaboratorService service)
    {
        _service = service;
    }

    [HttpGet("{associationId}")]
    public async Task<ActionResult<AssociationProjectCollaboratorDTO>> GetById(Guid associationId)
    {
        var assoc = await _service.GetByIdAsync(associationId);

        return assoc.ToActionResult();
    }
}