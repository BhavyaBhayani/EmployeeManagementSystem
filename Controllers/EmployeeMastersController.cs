using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Json;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeMastersController : Controller
    {
        private readonly HttpClient _httpClient;
        public EmployeeMastersController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // GET: EmployeeMasters        
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7273/api/Employees/");
                if (response.IsSuccessStatusCode)
                {
                    var employees = await response.Content.ReadAsAsync<List<vmEmployeeData>>();
                    return View(employees);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception using the MyExceptionFilter
                var context = new ExceptionContext(new ActionContext(HttpContext, RouteData, new ActionDescriptor()), new List<IFilterMetadata>())
                {
                    Exception = ex
                };
                new MyExceptionFilter().OnException(context);
                return View("Error");
            }

        }

        // GET: EmployeeMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var response = await _httpClient.GetAsync("https://localhost:7273/api/Employees/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var employeeMaster = await response.Content.ReadAsAsync<vmEmployeeData>();
                    return View(employeeMaster);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception using the MyExceptionFilter
                var context = new ExceptionContext(new ActionContext(HttpContext, RouteData, new ActionDescriptor()), new List<IFilterMetadata>())
                {
                    Exception = ex
                };
                new MyExceptionFilter().OnException(context);
                return View("Error");
            }
        }

        // GET: EmployeeMasters/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var departmentData = await _httpClient.GetAsync("https://localhost:7273/api/Employees/GetDepartments");
                if (departmentData != null)
                {
                    var deptData = departmentData.Content.ReadAsAsync<List<DepartmentMaster>>();
                    ViewBag.Departments = deptData.Result.Select(d => new { d.DepartmentId, d.DepartmentName });
                }
                return View();
            }
            catch (Exception ex)
            {
                // Handle the exception using the MyExceptionFilter
                var context = new ExceptionContext(new ActionContext(HttpContext, RouteData, new ActionDescriptor()), new List<IFilterMetadata>())
                {
                    Exception = ex
                };
                new MyExceptionFilter().OnException(context);
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeMaster employeeMaster)
        {
            try
            {
                if (employeeMaster == null)
                {
                    return NotFound();
                }
                else
                {
                    var jsonData = new StringContent(JsonConvert.SerializeObject(employeeMaster), Encoding.UTF8, "application/json");
                    var employeeDaya = await _httpClient.PostAsync("https://localhost:7273/api/Employees/", jsonData);
                    if (employeeDaya.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception using the MyExceptionFilter
                var context = new ExceptionContext(new ActionContext(HttpContext, RouteData, new ActionDescriptor()), new List<IFilterMetadata>())
                {
                    Exception = ex
                };
                new MyExceptionFilter().OnException(context);
                return View("Error");
            }
        }
        // GET: EmployeeMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var response = await _httpClient.GetAsync("https://localhost:7273/api/Employees/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var employeeMaster = await response.Content.ReadAsAsync<vmEmployeeData>();

                    var departmentData = await _httpClient.GetAsync("https://localhost:7273/api/Employees/GetDepartments");
                    if (departmentData != null)
                    {
                        var deptData = departmentData.Content.ReadAsAsync<List<DepartmentMaster>>();
                        ViewBag.Departments = deptData.Result.Select(d => new { d.DepartmentId, d.DepartmentName });
                    }
                    if (employeeMaster == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return View(employeeMaster);
                    }
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception using the MyExceptionFilter
                var context = new ExceptionContext(new ActionContext(HttpContext, RouteData, new ActionDescriptor()), new List<IFilterMetadata>())
                {
                    Exception = ex
                };
                new MyExceptionFilter().OnException(context);
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(vmEmployeeData employee)
        {

            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync("https://localhost:7273/api/Employees", jsonContent);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {
                // Handle the exception using the MyExceptionFilter
                var context = new ExceptionContext(new ActionContext(HttpContext, RouteData, new ActionDescriptor()), new List<IFilterMetadata>())
                {
                    Exception = ex
                };
                new MyExceptionFilter().OnException(context);
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var response = await _httpClient.DeleteAsync("https://localhost:7273/api/Employees/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle the exception using the MyExceptionFilter
                var context = new ExceptionContext(new ActionContext(HttpContext, RouteData, new ActionDescriptor()), new List<IFilterMetadata>())
                {
                    Exception = ex
                };
                new MyExceptionFilter().OnException(context);
                return View("Error");
            }
        }
    }
}
