using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Data.Repositories;
using DC.WebApi.Core.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace DC.WebApi.Core.Domain
{
    public class PropertyDomain : IPropertyDomain
    {
        private readonly IPropertyRepository _repo;
        private readonly IEmployeeRepository _empRepo;
        private readonly IImageHelper _imageHelper;

        public PropertyDomain(IPropertyRepository repo, IEmployeeRepository empRepo, IImageHelper imageHelper)
        {
            _repo = repo;
            _empRepo = empRepo;
            _imageHelper = imageHelper;
        }

        public async Task<PropertyEntity> CreatePropertyAsync(PropertyCreateModel property, CancellationToken token)
        {

            var PropertyDb = new PropertyEntity(
                property.Alias,
                property.Address,
                property.BtwnStreet1,
                property.BtwnStreet2,
                property.HoursService,
                property.CostService,
                property.Comments);

            List<PropertyEmployeeEntity> employees = new List<PropertyEmployeeEntity>();

            foreach(var employeeId in property.EmployeesList)
            {
                employees.Add(new PropertyEmployeeEntity(employeeId));
            }

            PropertyDb.PropertyEmployees = employees;


            //image part
            foreach(var image in property.ReferencePhotosList)
            {
                //we are going to save each image in a subfolder using the alias of the property
                string referencePhotoUrl = await _imageHelper.SaveImage(image, property.Alias);

                PropertyDb.ReferencePhotosList.Add(referencePhotoUrl);
            }


            try
            {
                await _repo.AddAsync(PropertyDb);

                await _repo.SaveChangesAsync();
            }
            catch (Exception)
            {
                //if we can´t succefuly add the property, we have to delete the files that we added
                foreach(var imageUrl in PropertyDb.ReferencePhotosList)
                {
                    _imageHelper.DeleteImage(imageUrl);
                }

                PropertyDb.ReferencePhotosList.Clear();
                throw;
            }

            return PropertyDb;
        }

        public async Task<int> DeleteAsync(PropertyEntity property, CancellationToken token)
        {
            if (property == default)
                throw new ArgumentNullException(nameof(property));

            property.IsActive = false;
            _repo.Update(property);

            return await _repo.SaveChangesAsync();
        }

        public Task<PropertyEntity> FindByAsync(string aliasProp, CancellationToken token)
        {
            var property = _repo.FindByAsync(aliasProp, token);

            if (property == default)
                return default;

            return property;
        }

        public Task<PropertyEntity> FindByIdAsync(long idProp, CancellationToken token)
        {
            var property = _repo.FindByIdAsync(idProp, token);

            if (property == default)
                return default;

            return property;
        }

        public Task<PropertyEntity> FindInactiveByIdAsync(long idProp, CancellationToken token)
        {
            var property = _repo.FindInactiveByIdAsync(idProp, token);

            if (property == default)
                return default;

            return property;
        }

        public Task<List<PropertyEntity>> GetAllAsync(CancellationToken token)
        {
            return _repo.GetAllAsync(token);
        }

        public Task<List<PropertyEntity>> GetAllInactiveAsync(CancellationToken token)
        {
            return _repo.GetAllInactiveAsync(token);
        }

        public async Task<string> GetImagesPath(string alias, string guid, CancellationToken token)
        {
            return await _repo.FindImagesUrl(alias, guid, token);
        }

        public async Task<int> UpdateAsync(PropertyEntity propDb, PropertyUpdateModel property, CancellationToken token)
        {

            bool photoReferenceWasUpdated = false;
            if (propDb == null)
                throw new ArgumentNullException(nameof(propDb));

            if (!String.IsNullOrEmpty(property.Alias))
                propDb.Alias = property.Alias;
            if (!String.IsNullOrEmpty(property.Address))
                propDb.Address = property.Address;
            if (!String.IsNullOrEmpty(property.BtwnStreet1))
                propDb.BtwnStreet1 = property.BtwnStreet1;
            if (!String.IsNullOrEmpty(property.BtwnStreet2))
                propDb.BtwnStreet2 = property.BtwnStreet2;
            if (property.HoursService!=default)
                propDb.HoursService = property.HoursService;
            if (property.CostService != default)
                propDb.CostService = property.CostService;
            if (property.Comments != default)
                propDb.Comments = property.Comments;
            if (property.ReferencePhotosList != default)
            {

                //if the organization already had a logo we have to delete it first
                if (propDb.ReferencePhotosList != default)
                {

                    foreach (var imageUrl in propDb.ReferencePhotosList)
                    {
                        _imageHelper.DeleteImage(imageUrl);
                    }

                    propDb.ReferencePhotosList.Clear();
                }



                foreach (var image in property.ReferencePhotosList)
                {
                    //we are going to save each image in a subfolder using the alias of the property
                    string referencePhotoUrl = await _imageHelper.SaveImage(image, property.Alias);

                    propDb.ReferencePhotosList.Add(referencePhotoUrl);
                }

                photoReferenceWasUpdated = true;
            }
                
            if (property.EmployeeList != default)
            {
                List<PropertyEmployeeEntity> employees = new List<PropertyEmployeeEntity>();

                foreach(var employeeId in property.EmployeeList)
                {
                    employees.Add(new PropertyEmployeeEntity(employeeId));
                }

                propDb.PropertyEmployees = employees;
            }



            if (photoReferenceWasUpdated)
            {
                try
                {
                    _repo.Update(propDb);

                    return await _repo.SaveChangesAsync();
                }
                catch (Exception)
                {
                    //if we can´t succefuly add the property, we have to delete the files that we added
                    foreach (var imageUrl in propDb.ReferencePhotosList)
                    {
                        _imageHelper.DeleteImage(imageUrl);
                    }

                    propDb.ReferencePhotosList.Clear();
                    throw;
                }
            }

            _repo.Update(propDb);

            return await _repo.SaveChangesAsync();

        }
    }
}
