using DesktopModel.Model;

namespace DesktopModel.Services
{
    public interface IProductservice
    {
        public Task<List<Product>> GetData();
        public Task<string> AddData(List<Product> Product);
        public Task<string> Updatedata(List<Product> Product);
        public Task<List<Product>> GetRequestData();
        public Task<string> ApproveData(List<Product> Product);
    }
}
