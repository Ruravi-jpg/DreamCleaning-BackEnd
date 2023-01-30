using DC.WebApi.Api;
using DC.WebApi.Common;
using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Data.Repositories;
using DC.WebApi.Core.Domain.Models;
using DC.WebApi.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.Replication.PgOutput.Messages;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace DC.WebApi.Core.Domain
{
    public class PropertyDomain : IPropertyDomain
    {
        private readonly IPropertyRepository _repo;
        private readonly IImageHelper _imageHelper;
        private readonly IWorkUnitRepository _workRepo;

        public PropertyDomain(IPropertyRepository repo, IWorkUnitRepository workRepo, IImageHelper imageHelper)
        {
            _repo = repo;
            _imageHelper = imageHelper;
            _workRepo = workRepo;
        }

        public async Task<int> AddPhotosAsync(IFormFileCollection photos, PropertyEntity propDb, CancellationToken token)
        {
            if(propDb.ReferencePhotosList != default)
            {
                foreach(var image in propDb.ReferencePhotosList)
                {
                    _imageHelper.DeleteImage(image);
                }
                propDb.ReferencePhotosList.Clear();
            }

            List<string> photosUrl = new List<string>();

            foreach(var image in photos)
            {
                photosUrl.Add(await _imageHelper.SaveImage(image, propDb.Id.ToString()));
            }

            int result = 0;

            try
            {
                propDb.ReferencePhotosList = photosUrl;

                _repo.Update(propDb);

                result = await _repo.SaveChangesAsync();
            }
            catch (Exception)
            {
                foreach(var image in photosUrl)
                {
                    _imageHelper.DeleteImage(image);
                }

                propDb.ReferencePhotosList.Clear();

                throw;
            }

            return result;
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

            
            await _repo.AddAsync(PropertyDb);

            await _repo.SaveChangesAsync();
            

            return PropertyDb;
        }

        public async Task<int> CreateWorkUnit(PropertyEntity propDb, List<WorkUnitCreateModel> workUnits, CancellationToken token)
        {
            foreach(var workUnit in workUnits)
            {
                
                var startTimeMatch = Regex.Match(workUnit.StartTime, Constants.TimeValidationregex);
                var finishTimeMatch = Regex.Match(workUnit.FinishTime, Constants.TimeValidationregex);

                if (!startTimeMatch.Success || !finishTimeMatch.Success)
                {
                    DCException.ThrowInvalidTimeFormat();
                }

                var WorkUnitDb = new WorkUnitEntity(
                workUnit.EmployeeId,
                TimeSpan.Parse(workUnit.StartTime),
                TimeSpan.Parse(workUnit.FinishTime),
                workUnit.DayToWork
                )
                {
                    PropertyParent = propDb
                };

                propDb.WorkList.Add(WorkUnitDb);
            }
            

            _repo.Update(propDb);

            await _repo.SaveChangesAsync();

            return await _repo.SaveChangesAsync();
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

        public async Task<WorkUnitEntity> FindWorkUnitByIdAsync(long workUnitId, CancellationToken token)
        {
            var workUnit = await _workRepo.FindByIdAsync(workUnitId, token);

            if(workUnit == default)
                return default;

            return workUnit;
        }

        public Task<List<PropertyEntity>> GetAllAsync(CancellationToken token)
        {
            return _repo.GetAllAsync(token);
        }

        public Task<List<PropertyEntity>> GetAllInactiveAsync(CancellationToken token)
        {
            return _repo.GetAllInactiveAsync(token);
        }

        public async Task<string> GetImagesPath(long id, string guid, CancellationToken token)
        {
            return await _repo.FindImagesUrl(id, guid, token);
        }

        public Task<List<WorkUnitEntity>> GetEmployeeWorkunitsAsync(long employeeId, CancellationToken token)
        {
            return _workRepo.GetEmployeeWorkUnits(employeeId, token);
        }

        public async Task<int> UpdateAsync(PropertyEntity propDb, PropertyUpdateModel property, CancellationToken token)
        {
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


            _repo.Update(propDb);

            return await _repo.SaveChangesAsync();

        }

        public async Task<int> UpdateWorkUnit(WorkUnitEntity workUnitDb, WorkUnitUpdateModel workUnituUpdate, CancellationToken token)
        {
            if (workUnitDb == null)
                throw new ArgumentNullException(nameof(workUnitDb));
            
            

            
            if (workUnituUpdate.EmployeeId != default)
                workUnitDb.EmployeeId = workUnituUpdate.EmployeeId;
            if (workUnituUpdate.StartTime != default)
            {
                var startTimeMatch = Regex.Match(workUnituUpdate.StartTime, Constants.TimeValidationregex);

                if (!startTimeMatch.Success)
                {
                    DCException.ThrowInvalidTimeFormat();
                }

                workUnitDb.StartTime = TimeSpan.Parse(workUnituUpdate.StartTime);
            }
               
            if (workUnituUpdate.FinishTime != default)
            {
                var finishTimeMatch = Regex.Match(workUnituUpdate.FinishTime, Constants.TimeValidationregex);
                if (!finishTimeMatch.Success)
                {
                    DCException.ThrowInvalidTimeFormat();
                }
                workUnitDb.FinishTime = TimeSpan.Parse(workUnituUpdate.FinishTime);
            }
               
            if (workUnituUpdate.DayToWork != default)
                workUnitDb.DayToWork = workUnituUpdate.DayToWork;

            _workRepo.Update(workUnitDb);

            return await _workRepo.SaveChangesAsync();
        }

        public async Task<List<WorkUnitEntity>> GetPropertyWorkunitsAsync(long propId, CancellationToken token)
        {
            return await _workRepo.GetPropertyWorkUnits(propId, token);
        }

        public async Task<int> DeleteWorkUnitAsync(WorkUnitEntity workUnit, CancellationToken token)
        {
            if(workUnit == default)
                throw new ArgumentNullException(nameof(workUnit));

            _workRepo.Remove(workUnit);

            //workUnit.IsActive = false;
            //_workRepo.Update(workUnit);

            return await _workRepo.SaveChangesAsync();
        }
    }
}
