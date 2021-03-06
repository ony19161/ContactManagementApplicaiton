﻿using CMA.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbModels = CMA.Db.Models;
using RequstModels = CMA.DTO.RequestModels;
using RepositoryModels = CMA.Repository.Models;
using ViewModels = CMA.DTO.ViewModels;

namespace CMA_Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        private List<ViewModels.IdAndValue> GetDropdownCategories(RepositoryModels.PagedList<DbModels.Category> categories)
        {
            var vCategories = new List<ViewModels.IdAndValue>();
            foreach (var sCategory in categories)
            {
                vCategories.Add(new ViewModels.IdAndValue
                {
                    Id = sCategory.Id.ToString(),
                    Value = sCategory.Title
                });
            }

            return vCategories;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery]RequstModels.UserFilter categoryFilter)
        {
            try
            {
                var pagedCagegoryList = await _categoryRepository.GetCategories(categoryFilter);

                if (categoryFilter.IsIdValue)
                {
                    return Ok(new {
                        Categories = GetDropdownCategories(pagedCagegoryList)
                    });
                }
                else
                {
                    var vCategories = new List<ViewModels.Category>();
                    foreach (var sCategory in pagedCagegoryList)
                    {
                        vCategories.Add(new ViewModels.Category
                        {
                            Id = sCategory.Id.ToString(),
                            Title = sCategory.Title,
                            Description = sCategory.Description
                        });
                    }

                    return Ok(new
                    {
                        Pagination = new ViewModels.Pagination(pagedCagegoryList.PageIndex, pagedCagegoryList.PageSize, pagedCagegoryList.TotalCount, pagedCagegoryList.TotalPages),
                        Categories = vCategories

                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetCategory(string id)
        {
            var sCategory = await _categoryRepository.Get(Guid.Parse(id));

            return Ok(new ViewModels.Category {
                Id = sCategory.Id.ToString(),
                Title = sCategory.Title,
                Description = sCategory.Description
            });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCategory(RequstModels.Category rCategory)
        {
            var sCategory = new DbModels.Category {
                Id = Guid.NewGuid(),
                Title = rCategory.Title,
                Description = rCategory.Description,
                RequestFrom = rCategory.RequestFrom,
                CreatedBy = "system", // get user from token
                CreatedAt = DateTime.UtcNow,
                ModifiedBy = "system", // get user from token
                ModifiedAt = DateTime.UtcNow
            };
            _categoryRepository.Add(sCategory);
            var isAdded = await _categoryRepository.Commit();

            if (isAdded)
            {
                return Ok(new ViewModels.Category
                {
                    Id = sCategory.Id.ToString(),
                    Title = sCategory.Title,
                    Description = sCategory.Description
                });
            }
            else
            {
                return BadRequest();
            }            
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCategory(RequstModels.Category rCategory)
        {
            var sCategory = await _categoryRepository.Get(Guid.Parse(rCategory.Id));
            sCategory.Title = rCategory.Title;
            sCategory.Description = rCategory.Description;
            sCategory.ModifiedAt = DateTime.Now;
            sCategory.ModifiedBy = "system";// get user from token

            var isModified = await _categoryRepository.Commit();

            if (isModified)
            {
                return Ok(new ViewModels.Category
                {
                    Id = sCategory.Id.ToString(),
                    Title = sCategory.Title,
                    Description = sCategory.Description
                });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            var vCategories = new List<ViewModels.ExportCategory>();
            foreach (var sCategory in categories)
            {
                vCategories.Add(new ViewModels.ExportCategory
                {
                    Title = sCategory.Title,
                    Description = sCategory.Description
                });
            }

            return Ok(vCategories);
        }

    }
}