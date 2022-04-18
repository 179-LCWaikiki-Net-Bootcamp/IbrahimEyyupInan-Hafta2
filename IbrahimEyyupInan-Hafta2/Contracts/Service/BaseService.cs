using IbrahimEyyupInan_Hafta2.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Service
{
    public interface BaseService<Entity,View,Dto>
    {
        public IEnumerable<View> getList();
        public  Task<IEnumerable<View>> getListAsync();
        public View findById(int id);
        public Task<View> findByIdAsync(int id);

        public View create(Dto productDto);

        public Task<View> createAsync(Dto productDto);
        public void update(int id, Dto productDto);
        public Task updateAsync(int id, Dto productDto);
        public void delete(int id);
        public Task deleteAsync(int id);
    }
}
