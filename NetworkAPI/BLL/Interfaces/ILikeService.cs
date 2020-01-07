using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILikeService
    {
        Task<bool> PutLike(int postId, int userId);
        Task<bool> DeleteLike(int postId, int userId);
    }
}
