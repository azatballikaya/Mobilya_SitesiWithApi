﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Mobilya_Sitesi.Models;
using Mobilya_Sitesi.Models.ViewModels.Role;
using Mobilya_Sitesi.Models.ViewModels.User;
using Newtonsoft.Json;
using System.Text;

namespace Mobilya_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Superadmin")]
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage;
           

             responseMessage=  await client.GetAsync("http://localhost:5198/api/User/GetAllUsersWithRoles");
            
         
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultUserViewModel>>(jsonData);
                
                List<string> roles = new List<string>();
                roles.Add("Superadmin");
                roles.Add("Admin");
                roles.Add("Customer");

                ViewBag.Roles = new SelectList(roles);


                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string id = null)
        {
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage;
            if (id == "Tümü")
            {

                responseMessage = await client.GetAsync("http://localhost:5198/api/User/GetAllUsersWithRoles");
            }
            else
            {
                responseMessage = await client.GetAsync($"http://localhost:5198/api/User/GetAllUsersWithRoles/{id}");

            }
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultUserViewModel>>(jsonData);

            


                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                var client=_httpClientFactory.CreateClient();
                var jsonData=JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
                var responseMessage = await client.PostAsync("http://localhost:5198/api/User/AddUser",content);
                if(responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                
                
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5198/api/User/GetUserWithRoles/{id}");
            var responseMessage2 = await client2.GetAsync("http://localhost:5198/api/Role");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData2;
                List<ResultRoleViewModel> value2;

                jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                value2 = JsonConvert.DeserializeObject<List<ResultRoleViewModel>>(jsonData2);


                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<EditUserViewModel>(jsonData);

                value.Roles=value2.Select(x=>new ResultRoleViewModel
                {
                    RoleId=x.RoleId,
                    RoleName=x.RoleName,
                    IsChecked=value.Roles.Any(y=>y.RoleName==x.RoleName),
                } ).ToList();
               
                ViewBag.Roles = value2;
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel editUserViewModel)
        {

            var client=_httpClientFactory.CreateClient();
            editUserViewModel.Roles=editUserViewModel.Roles.Where(x=>x.IsChecked).ToList();
            var jsonData = JsonConvert.SerializeObject(new
            {
                UserId=editUserViewModel.UserId,
                UserName=editUserViewModel.UserName,
                Password=editUserViewModel.Password,
                RoleIds=editUserViewModel.Roles.Select(r=>r.RoleId).ToList()

            });
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("http://localhost:5198/api/User", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(editUserViewModel);
        }

    }
}