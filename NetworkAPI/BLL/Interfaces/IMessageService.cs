using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageService
    {
        Task<MessageDTO> GetMessage(int messageId);
        Task<IEnumerable<MessageDTO>> GetMessages(int userId, int companionId);
        Task<MessageDTO> AddMessage(int userId, MessageToCreateDTO message);
        Task<bool> DeleteMessage(int userId, int messageId);
        Task<bool> MarkAsRead(int userId, int messageId);
    }
}
