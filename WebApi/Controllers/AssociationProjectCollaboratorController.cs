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

    [HttpGet("{id}/details")]
    public async Task<ActionResult<AssociationProjectCollaboratorDetailsDTO>> GetAssociationDetailsAsync(Guid id)
    {
        var result = await _service.GetAssociationDetailsAsync(id);
        return result.ToActionResult();
    }

    [HttpGet("collaborator/{collaboratorId}/details")]
    public async Task<ActionResult<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>> GetAllWithDetailsByCollaboratorIdAsync(Guid collaboratorId)
    {
        var result = await _service.GetAllWithDetailsByCollaboratorIdAsync(collaboratorId);
        return result.ToActionResult();
    }

    [HttpGet("project/{projectId}/details")]
    public async Task<ActionResult<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>> GetAllWithDetailsByProjectIdAsync(Guid projectId)
    {
        var result = await _service.GetAllWithDetailsByProjectIdAsync(projectId);
        return result.ToActionResult();
    }
}