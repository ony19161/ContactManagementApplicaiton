using CMA.Repository.Interfaces;
using CMA_Server.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbModels = CMA.Db.Models;
using RequstModels = CMA.DTO.RequestModels;
using ViewModels = CMA.DTO.ViewModels;

namespace CMA_Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ContactController(IContactRepository contactRepository, ICategoryRepository categoryRepository)
        {
            _contactRepository = contactRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts([FromQuery]RequstModels.PagingFilter pagingFilter)
        {
            try
            {
                var pagedCagegoryList = await _contactRepository.GetContacts(pagingFilter);
                var vContacts = new List<ViewModels.Contact>();
                foreach (var sContact in pagedCagegoryList)
                {
                    vContacts.Add(new ViewModels.Contact
                    {
                        Id = sContact.Id.ToString(),
                        Name = sContact.Name,
                        Email = sContact.Email,
                        Address = sContact.Address,
                        Mobile = sContact.Mobile,
                        ProfilePicture = sContact.ProfilePicture,
                        Category = sContact.Category.Title,
                        CategoryId = sContact.Category.Id.ToString()
                    });
                }

                return Ok(new
                {
                    Pagination = new ViewModels.Pagination(pagedCagegoryList.PageIndex, pagedCagegoryList.PageSize, pagedCagegoryList.TotalCount, pagedCagegoryList.TotalPages),
                    Contacts = vContacts
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetContact(string id)
        {
            var sContact = await _contactRepository.Get(Guid.Parse(id));

            return Ok(new ViewModels.Contact
            {
                Id = sContact.Id.ToString(),
                Name = sContact.Name,
                Email = sContact.Email,
                Address = sContact.Address,
                Mobile = sContact.Mobile,
                ProfilePicture = sContact.ProfilePicture,
                CategoryId = sContact.Category.Id.ToString()
            });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddContact(RequstModels.Contact rContact)
        {
            var sCatetory = await _categoryRepository.Get(Guid.Parse(rContact.CategoryId));
            var sContact = new DbModels.Contact
            {
                Id = Guid.NewGuid(),
                Name = rContact.Name,
                Email = rContact.Email,
                Address = rContact.Address,
                Mobile = rContact.Mobile,
                ProfilePicture = rContact.ProfilePicture,
                Category = sCatetory,
                CreatedBy = "system", // get user from token
                CreatedAt = DateTime.UtcNow,
                ModifiedBy = "system", // get user from token
                ModifiedAt = DateTime.UtcNow
            };
            _contactRepository.Add(sContact);
            var isAdded = await _contactRepository.Commit();

            if (isAdded)
            {
                return Ok(new 
                {
                    Status = CMAContants.Success
                });
            }
            else
            {
                return BadRequest(new
                {
                    Status = CMAContants.Failed
                });
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCategory(RequstModels.Contact rContact)
        {
            var sCatetory = await _categoryRepository.Get(Guid.Parse(rContact.CategoryId));
            var sContact = await _contactRepository.Get(Guid.Parse(rContact.Id));
            sContact.Name = rContact.Name;
            sContact.Email = rContact.Email;
            sContact.Mobile = rContact.Mobile;
            sContact.Address = rContact.Address;
            sContact.Category = sCatetory;
            //sContact.ProfilePicture = rContact.ProfilePicture;
            sContact.ModifiedAt = DateTime.Now;
            sContact.ModifiedBy = "system";// get user from token

            var isModified = await _contactRepository.Commit();

            if (isModified)
            {
                return Ok(new
                {
                    Status = CMAContants.Success
                });
            }
            else
            {
                return BadRequest(new
                {
                    Status = CMAContants.Failed
                });
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactRepository.GetContactsToExport();
            var vContacts = new List<ViewModels.ExportContact>();
            foreach (var sContact in contacts)
            {
                vContacts.Add(new ViewModels.ExportContact
                {
                    Name = sContact.Name,
                    Email = sContact.Email,
                    Address = sContact.Address,
                    Mobile = sContact.Mobile,
                    Category = sContact.Category.Title
                });
            }

            return Ok(vContacts);
        }
    }
}