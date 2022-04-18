using IbrahimEyyupInan_Hafta2.Model.Dto;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IbrahimEyyupInan_Hafta2.Contracts.Service
{
    public interface IBaseService<Entity,View,Dto>
    {
        public  Task<IEnumerable<View>> getListAsync();
        
        public Task<View> findByIdAsync(int id);


        public Task<View> createAsync(Dto productDto);
        public Task updateAsync(int id, Dto productDto);
        public Task deleteAsync(int id);
    }
}
