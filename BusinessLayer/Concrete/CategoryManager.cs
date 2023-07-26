using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //Burada EfCategoryRepositories kullanmamızın sebebi tamamıyla entity framework'e bağımlı kalmamak istememiz.Ayrıca Generic kullanmamamızın sebebi de zaten entity reposunun genericten miras alması.Ve ayrıca ICategoryDal'dan da miras alıyor.
        //O da IGenericDal'dan miras alıyor yani iç içe bir yapı mevcut ve bu şekilde işimizi halledebiliyoruz.Fakat EfCategoryRepositories'i kullanmamızın sebebi bağımlı kalmamak.Sonradan Framework değiştirdiğimizde kolay şekilde değiştirebilmemizi sağlamak.

        ICategoryDal _categoryDal;

      
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }
    }
}
