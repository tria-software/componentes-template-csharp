using ProjetoTemplate.BL.Excel;
using ProjetoTemplate.Domain.DTO;
using ProjetoTemplate.Domain.DTO.EntityName;
using ProjetoTemplate.Domain.Helpers;
using System.Threading.Tasks;

namespace ProjetoTemplate.BL
{
    public interface IEntityNameBO
    {
        Task<GridViewData<EntityNameListDTO>> GetAll(EntityNameFilterDTO filter);
        Task<bool> SaveUpdate(EntityNameDTO user);
        Task<bool> Delete(long userID);
        Task<bool> ActivateDisable(ActivateDisableDeleteDTO model);
        Task<EntityNameDTO> GetById(long id);
        Task<FileDownloadDTO> Export2Excel(EntityNameFilterDTO filter);
    }
}
