using FarmTradeApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using FarmTradeApp.Core.Models;
using FarmTradeApp.Core.Dtos;

namespace FarmTradeApp.Controllers.api
{
    public class StoragesController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public StoragesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET /api/storages
        public IHttpActionResult GetStorages()
        {
            var storages = unitOfWork.Storages
                .GetStoragesWithLocation()
                .Select(Mapper.Map<Storage, StorageDto>);

            return Ok(storages);
        }

        // GET /api/storage/1
        public StorageDto GetStorage(int id)
        {
            var storage = unitOfWork.Storages.GetStorage(id);

            if (storage == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Storage, StorageDto>(storage);
        }

        // POST /api/storages
        public IHttpActionResult AddStorage(StorageDto storageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var storage = Mapper.Map<StorageDto, Storage>(storageDto);
            unitOfWork.Storages.AddStorage(storage);
            unitOfWork.Complete();

            storageDto.Id = storage.Id;

            return Created(new Uri(Request.RequestUri + "/" + storage.Id), storageDto);
        }

        // PUT /api/storages/1
        public void UpdateStorage(int id, StorageDto storageDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var storageDb = unitOfWork.Storages.GetStorage(id);

            if (storageDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(storageDto, storageDb);
            //storageDb.Name = storage.Name;
            //storageDb.LocationID = storage.LocationID;

            unitOfWork.Complete();
        }

        // DELETE /api/storages/1
        [HttpDelete]
        public void DeleteStorage(int id)
        {
            var storageDb = unitOfWork.Storages.GetStorage(id);

            if (storageDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            unitOfWork.Storages.RemoveStorage(storageDb);
            unitOfWork.Complete();
        }
    }
}
