using System.Threading.Tasks;

namespace ESparrow.Utils.Data.Interfaces
{
    public interface IAsyncDataTransmitter<TData>
    {
        Task<TData> GetData();
        Task SetData(TData data);
    }
}